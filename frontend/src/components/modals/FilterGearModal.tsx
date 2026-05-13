import { colours, spacing, borderRadius } from '@styles/variables';
import { Body, Heading, Label } from '@ui/Typography';
import { Modal, StyleSheet, TouchableOpacity, View, ScrollView } from 'react-native';
import { X } from 'lucide-react-native';
import { Dropdown } from '@ui/Dropdown';
import { GearCategory, Sex, Size, StorageLocation } from '@api/common/enums';
import { 
  getGearCategoryOptions, 
  getSexOptions, 
  getSizeOptions, 
  getStorageLocationOptions 
} from '@utils/enumHelpers';
import { Button } from '@ui/Button';
import { useState, useEffect } from 'react';

interface FilterGearModalProps {
  visible: boolean;
  onClose: () => void;
  filters: {
    gearCategory?: GearCategory;
    sex?: Sex;
    size?: Size;
    storageLocation?: StorageLocation;
  };
  onApply: (filters: { 
    gearCategory?: GearCategory;
    sex?: Sex;
    size?: Size;
    storageLocation?: StorageLocation;
  }) => void;
}

const FilterGearModal = ({ visible, onClose, filters, onApply }: FilterGearModalProps) => {
  const [tempFilters, setTempFilters] = useState(filters);

  useEffect(() => {
    if (visible) {
      setTempFilters(filters);
    }
  }, [visible, filters]);

  const handleApply = () => {
    onApply(tempFilters);
    onClose();
  };

  const handleReset = () => {
    const reset = { 
      gearCategory: undefined,
      sex: undefined,
      size: undefined,
      storageLocation: undefined
    };
    setTempFilters(reset);
    onApply(reset);
    onClose();
  };

  return (
    <Modal visible={visible} transparent animationType="slide">
      <View style={styles.modalOverlay}>
        <View style={styles.modalContent}>
          <View style={styles.header}>
            <Heading style={styles.title}>Filter Gear</Heading>
            <TouchableOpacity onPress={onClose} style={styles.closeButton}>
              <X size={24} color={colours.textPrimary} />
            </TouchableOpacity>
          </View>

          <ScrollView style={styles.body}>
            <Dropdown
              label="Gear Category"
              options={[{ label: 'All Categories', value: undefined }, ...getGearCategoryOptions()]}
              selectedValue={tempFilters.gearCategory}
              onValueChange={(value) => setTempFilters({ ...tempFilters, gearCategory: value })}
            />
            
            <Dropdown
              label="Size"
              options={[{ label: 'All Sizes', value: undefined }, ...getSizeOptions()]}
              selectedValue={tempFilters.size}
              onValueChange={(value) => setTempFilters({ ...tempFilters, size: value })}
            />

            <Dropdown
              label="Sex"
              options={[{ label: 'Any', value: undefined }, ...getSexOptions()]}
              selectedValue={tempFilters.sex}
              onValueChange={(value) => setTempFilters({ ...tempFilters, sex: value })}
            />

            <Dropdown
              label="Storage Location"
              options={[{ label: 'All Locations', value: undefined }, ...getStorageLocationOptions()]}
              selectedValue={tempFilters.storageLocation}
              onValueChange={(value) => setTempFilters({ ...tempFilters, storageLocation: value })}
            />
          </ScrollView>

          <View style={styles.footer}>
            <Button
              title="Reset"
              onPress={handleReset}
              variant="ghost"
              style={styles.resetButton}
            />
            <Button
              title="Apply Filters"
              onPress={handleApply}
              style={styles.applyButton}
            />
          </View>
        </View>
      </View>
    </Modal>
  );
};

const styles = StyleSheet.create({
  modalOverlay: {
    flex: 1,
    backgroundColor: 'rgba(0, 0, 0, 0.8)',
    justifyContent: 'center',
    padding: spacing.large,
  },
  modalContent: {
    backgroundColor: colours.background,
    borderRadius: 28,
    padding: spacing.large,
    maxHeight: '80%',
    borderWidth: 1,
    borderColor: colours.whiteOpacityStrong,
    elevation: 20,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 10 },
    shadowOpacity: 0.5,
    shadowRadius: 20,
  },
  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: spacing.large,
  },
  title: {
    fontSize: 24,
  },
  closeButton: {
    padding: spacing.small,
  },
  body: {
    marginBottom: spacing.large,
  },
  footer: {
    flexDirection: 'row',
    gap: spacing.medium,
  },
  resetButton: {
    flex: 1,
  },
  applyButton: {
    flex: 1,
  },
});

export default FilterGearModal;
