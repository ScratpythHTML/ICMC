import { colours, spacing, borderRadius } from '@styles/variables';
import { Body, Subheading, Label } from '@ui/Typography';
import { X, CheckSquare, Square, MapPin } from 'lucide-react-native';
import { useState } from 'react';
import { 
  Modal, 
  ScrollView, 
  StyleSheet, 
  TouchableOpacity, 
  View, 
  ActivityIndicator
} from 'react-native';
import { useUpdateGearItem } from '@api/gear-items/gearItemsApi';
import { useUserContext } from '@contexts/UserContext';
import { StorageLocation } from '@api/common/enums';
import { getStorageLocationOptions } from '@utils/enumHelpers';

interface ReturnGearModalProps {
  visible: boolean;
  onClose: () => void;
  gearItem: any;
}

const ReturnGearModal = ({ visible, onClose, gearItem }: ReturnGearModalProps) => {
  const { user } = useUserContext();
  const [inspected, setInspected] = useState(false);
  const [storageLocation, setStorageLocation] = useState<StorageLocation | null>(
    gearItem?.storageLocation ?? null
  );

  const { mutateAsync: updateGearItem, isPending: isSubmitting } = useUpdateGearItem();

  const handleReturn = async () => {
    if (storageLocation === null) return;

    const now = new Date().toISOString();
    
    // Calculate next inspection if inspected, otherwise keep existing
    const nextYear = new Date();
    nextYear.setFullYear(nextYear.getFullYear() + 1);

    try {
      await updateGearItem({
        id: gearItem.id,
        request: {
          id: gearItem.id,
          storageLocation: storageLocation,
          returnedDate: now,
          lentDate: null,
          lentToUserId: null,
          expectedReturnDate: null,
          // Only update inspection fields if checked
          ...(inspected ? {
            lastInspection: now,
            nextInspection: nextYear.toISOString(),
            inspectedByUserId: user?.id,
          } : {
            lastInspection: gearItem.lastInspection,
            nextInspection: gearItem.nextInspection,
            inspectedByUserId: gearItem.inspectedByUserId,
          })
        }
      });
      onClose();
    } catch (e) {
      console.error(e);
    }
  };

  if (!gearItem) return null;

  return (
    <Modal visible={visible} animationType="fade" transparent>
      <View style={styles.overlay}>
        <View style={styles.modalCard}>
          <View style={styles.header}>
            <Subheading>Return Gear</Subheading>
            <TouchableOpacity onPress={onClose}>
              <X size={24} color={colours.textPrimary} />
            </TouchableOpacity>
          </View>

          <ScrollView contentContainerStyle={styles.content}>
            <Body style={styles.gearName}>{gearItem.brand} {gearItem.model}</Body>
            <Label>TAG #{gearItem.toughTag}</Label>

            <View style={styles.divider} />

            {/* Storage Location - Required */}
            <View style={styles.section}>
              <Label style={styles.sectionLabel}>STORAGE LOCATION *</Label>
              <View style={styles.optionsGrid}>
                {getStorageLocationOptions().map((opt) => (
                  <TouchableOpacity 
                    key={opt.value}
                    style={[
                      styles.optionCard, 
                      storageLocation === opt.value && styles.optionCardSelected
                    ]}
                    onPress={() => setStorageLocation(opt.value)}
                  >
                    <MapPin size={18} color={storageLocation === opt.value ? colours.blue : colours.textMuted} />
                    <Body style={storageLocation === opt.value ? styles.optionTextSelected : {}}>{opt.label}</Body>
                  </TouchableOpacity>
                ))}
              </View>
            </View>

            {/* Inspection - Optional */}
            <TouchableOpacity 
              style={styles.checkboxRow} 
              onPress={() => setInspected(!inspected)}
              activeOpacity={0.7}
            >
              {inspected ? (
                <CheckSquare size={24} color={colours.success} />
              ) : (
                <Square size={24} color={colours.textMuted} />
              )}
              <View>
                <Body style={styles.checkboxText}>I have inspected this item</Body>
                <Label>Updates Last/Next Inspection dates</Label>
              </View>
            </TouchableOpacity>

            <TouchableOpacity 
              style={[styles.submitButton, (storageLocation === null || isSubmitting) && styles.submitButtonDisabled]}
              onPress={handleReturn}
              disabled={storageLocation === null || isSubmitting}
            >
              {isSubmitting ? (
                <ActivityIndicator color="#fff" />
              ) : (
                <Body style={styles.submitButtonText}>Complete Return</Body>
              )}
            </TouchableOpacity>
          </ScrollView>
        </View>
      </View>
    </Modal>
  );
};

const styles = StyleSheet.create({
  overlay: {
    flex: 1,
    backgroundColor: 'rgba(0,0,0,0.85)',
    justifyContent: 'center',
    padding: spacing.medium,
  },
  modalCard: {
    backgroundColor: colours.surface,
    borderRadius: borderRadius.large,
    borderWidth: 1,
    borderColor: colours.whiteOpacity,
    maxHeight: '80%',
  },
  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    padding: spacing.medium,
    borderBottomWidth: 1,
    borderBottomColor: colours.whiteOpacity,
  },
  content: {
    padding: spacing.medium,
    gap: spacing.medium,
  },
  gearName: {
    fontSize: 18,
    fontWeight: '700',
    color: colours.textPrimary,
    marginBottom: 2,
  },
  divider: {
    height: 1,
    backgroundColor: colours.whiteOpacity,
    marginVertical: spacing.small,
  },
  section: {
    gap: spacing.small,
  },
  sectionLabel: {
    fontSize: 10,
    letterSpacing: 1,
  },
  optionsGrid: {
    flexDirection: 'row',
    gap: spacing.small,
  },
  optionCard: {
    flex: 1,
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing.small,
    backgroundColor: colours.surfaceLight,
    padding: spacing.medium,
    borderRadius: borderRadius.medium,
    borderWidth: 1,
    borderColor: 'transparent',
  },
  optionCardSelected: {
    borderColor: colours.blue,
    backgroundColor: colours.blue + '10',
  },
  optionTextSelected: {
    color: colours.blue,
    fontWeight: '700',
  },
  checkboxRow: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing.medium,
    backgroundColor: colours.surfaceLight,
    padding: spacing.medium,
    borderRadius: borderRadius.medium,
    marginTop: spacing.small,
  },
  checkboxText: {
    fontWeight: '600',
    color: colours.textPrimary,
  },
  submitButton: {
    backgroundColor: colours.success,
    height: 56,
    borderRadius: borderRadius.medium,
    alignItems: 'center',
    justifyContent: 'center',
    marginTop: spacing.large,
  },
  submitButtonDisabled: {
    opacity: 0.5,
  },
  submitButtonText: {
    color: '#fff',
    fontWeight: '700',
    fontSize: 16,
  },
});

export default ReturnGearModal;
