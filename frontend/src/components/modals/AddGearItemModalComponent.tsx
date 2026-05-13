import { useAddGearItem } from '@api/gear-items/gearItemsApi';
import type { AddGearItemRequest } from '@api/gear-items/gearItemsTypes';
import type { RootStackParamList } from '@navigation/BootRouter';
import { type RouteProp, useRoute } from '@react-navigation/native';
import { spacing } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { Button } from '@ui/Button';
import { Card } from '@ui/Card';
import { DatePicker } from '@ui/DatePicker';
import { Dropdown } from '@ui/Dropdown';
import { Input } from '@ui/Input';
import { Heading, Subheading } from '@ui/Typography';
import {
  getGearCategoryOptions,
  getSexOptions,
  getSizeOptions,
  getStorageLocationOptions,
} from '@utils/enumHelpers';
import { useState } from 'react';
import { Modal, ScrollView, StyleSheet, View } from 'react-native';

const AddGearItemModalComponent = ({
  modalVisible,
  setModalVisible,
}: {
  modalVisible: boolean;
  setModalVisible: (value: boolean) => void;
}) => {
  const route = useRoute<RouteProp<RootStackParamList, 'GearItems'>>();
  const { gearCategory, storageLocation } = route.params;

  const [formData, setFormData] = useState<Partial<AddGearItemRequest>>({
    toughTag: '',
    gearCategory: gearCategory,
    storageLocation: storageLocation,
  });

  const { mutateAsync: addGearItem } = useAddGearItem();

  const handleInputChange = (
    key: keyof AddGearItemRequest,
    value: string | number | undefined
  ) => {
    setFormData((prev) => ({ ...prev, [key]: value }));
  };

  const handleOnPress = async () => {
    try {
      await addGearItem(formData as AddGearItemRequest);
      setModalVisible(false);
    } catch (e) {
      console.error(e);
    }
  };

  return (
    <Modal visible={modalVisible} animationType="slide">
      <BackgroundComponent>
        <ScrollView contentContainerStyle={styles.scrollContent}>
          <Heading style={styles.title}>Add New Gear</Heading>

          <Card style={styles.section}>
            <Subheading style={styles.sectionTitle}>Identification</Subheading>
            <Input
              label="ToughTag #"
              placeholder="e.g. 112"
              keyboardType="numeric"
              onChangeText={(v) => handleInputChange('toughTag', v)}
            />
            <Input
              label="Brand"
              placeholder="e.g. Petzl"
              onChangeText={(v) => handleInputChange('brand', v)}
            />
            <Input
              label="Model"
              placeholder="e.g. Grigri"
              onChangeText={(v) => handleInputChange('model', v)}
            />
          </Card>

          <Card style={styles.section}>
            <Subheading style={styles.sectionTitle}>Classification</Subheading>
            <Dropdown
              label="Gear Category"
              options={getGearCategoryOptions()}
              selectedValue={formData.gearCategory}
              onValueChange={(v) => handleInputChange('gearCategory', v)}
            />
            <Dropdown
              label="Storage Location"
              options={getStorageLocationOptions()}
              selectedValue={formData.storageLocation}
              onValueChange={(v) => handleInputChange('storageLocation', v)}
            />
          </Card>

          <Card style={styles.section}>
            <Subheading style={styles.sectionTitle}>
              Physical Details
            </Subheading>
            <Dropdown
              label="Size"
              options={[{ label: 'None', value: -1 }, ...getSizeOptions()]}
              selectedValue={formData.size ?? -1}
              onValueChange={(v) =>
                handleInputChange('size', v === -1 ? undefined : v)
              }
            />
            <Dropdown
              label="Sex"
              options={[{ label: 'Unisex', value: -1 }, ...getSexOptions()]}
              selectedValue={formData.sex ?? -1}
              onValueChange={(v) =>
                handleInputChange('sex', v === -1 ? undefined : v)
              }
            />
            <Input
              label="Length (m)"
              placeholder="e.g. 60"
              keyboardType="numeric"
              onChangeText={(v) => handleInputChange('length', Number(v))}
            />
          </Card>

          <Card style={styles.section}>
            <Subheading style={styles.sectionTitle}>
              Dates & Inspection
            </Subheading>
            <DatePicker
              label="Date of Purchase"
              value={formData.dateOfPurchase}
              onChange={(v) => handleInputChange('dateOfPurchase', v)}
            />
            <DatePicker
              label="Manufacturer Expiry"
              value={formData.manufacturerExpiry}
              onChange={(v) => handleInputChange('manufacturerExpiry', v)}
            />
            <DatePicker
              label="Last Inspection"
              value={formData.lastInspection}
              onChange={(v) => handleInputChange('lastInspection', v)}
            />
            <DatePicker
              label="Next Inspection"
              value={formData.nextInspection}
              onChange={(v) => handleInputChange('nextInspection', v)}
            />
            <Input
              label="Inspected By (User ID)"
              placeholder="e.g. 1"
              keyboardType="numeric"
              onChangeText={(v) => handleInputChange('inspectedByUserId', Number(v))}
            />
          </Card>

          <Card style={styles.section}>
            <Subheading style={styles.sectionTitle}>
              Lending Initial State
            </Subheading>
            <Input
              label="Lent To (User ID)"
              placeholder="e.g. 2"
              keyboardType="numeric"
              onChangeText={(v) => handleInputChange('lentToUserId', Number(v))}
            />
            <Input
              label="Lent By (User ID)"
              placeholder="e.g. 1"
              keyboardType="numeric"
              onChangeText={(v) => handleInputChange('lentByUserId', Number(v))}
            />
            <DatePicker
              label="Lent Date"
              value={formData.lentDate}
              onChange={(v) => handleInputChange('lentDate', v)}
            />
          </Card>

          <View style={styles.actions}>
            <Button
              title="Add Gear Item"
              onPress={handleOnPress}
              variant="primary"
            />
            <Button
              title="Cancel"
              onPress={() => setModalVisible(false)}
              variant="ghost"
            />
          </View>
        </ScrollView>
      </BackgroundComponent>
    </Modal>
  );
};

const styles = StyleSheet.create({
  scrollContent: {
    padding: spacing.medium,
    paddingBottom: spacing.xxLarge,
  },
  title: {
    color: '#fff',
    textAlign: 'center',
    marginVertical: spacing.large,
  },
  section: {
    marginBottom: spacing.medium,
  },
  sectionTitle: {
    color: '#fff',
    fontSize: 16,
    marginBottom: spacing.medium,
    borderBottomWidth: 1,
    borderBottomColor: 'rgba(255, 255, 255, 0.2)',
    paddingBottom: spacing.xSmall,
  },
  actions: {
    gap: spacing.medium,
    marginTop: spacing.large,
  },
});

export default AddGearItemModalComponent;
