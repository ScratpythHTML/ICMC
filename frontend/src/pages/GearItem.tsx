import {
  useDeleteGearItem,
  useGetGearItem,
  useUpdateGearItem,
} from '@api/gear-items/gearItemsApi';
import type { UpdateGearItemRequest } from '@api/gear-items/gearItemsTypes';
import { useUserContext } from '@contexts/UserContext';
import type { RootStackParamList } from '@navigation/BootRouter';
import {
  type NavigationProp,
  type RouteProp,
  useNavigation,
  useRoute,
} from '@react-navigation/native';
import { colours, spacing } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { Badge } from '@ui/Badge';
import { Button } from '@ui/Button';
import { Card } from '@ui/Card';
import { ConfirmToast } from '@ui/ConfirmToast';
import { DatePicker } from '@ui/DatePicker';
import { Dropdown } from '@ui/Dropdown';
import HeaderComponent from '@ui/HeaderComponent';
import { InfoRow } from '@ui/InfoRow';
import { Input } from '@ui/Input';
import { Body, Heading, Subheading } from '@ui/Typography';
import {
  formatDate,
  getGearCategoryLabel,
  getGearCategoryOptions,
  getSexLabel,
  getSexOptions,
  getSizeLabel,
  getSizeOptions,
  getStorageLocationLabel,
  getStorageLocationOptions,
} from '@utils/enumHelpers';
import { useEffect, useState } from 'react';
import { ScrollView, StyleSheet, View } from 'react-native';

const GearItem = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const route = useRoute<RouteProp<RootStackParamList, 'GearItem'>>();
  const { id } = route.params;
  const { user } = useUserContext();
  const { data: gearItem, isLoading } = useGetGearItem(id);
  const { mutateAsync: updateGearItem } = useUpdateGearItem();
  const { mutateAsync: deleteGearItem } = useDeleteGearItem();

  const [isEditing, setIsEditing] = useState(false);
  const [showDeleteConfirm, setShowDeleteConfirm] = useState(false);
  const [editedItem, setEditedItem] = useState<UpdateGearItemRequest>({ id });

  useEffect(() => {
    if (gearItem && !isEditing) {
      setEditedItem({ ...gearItem });
    }
  }, [gearItem, isEditing]);

  const handleInputChange = (key: keyof UpdateGearItemRequest, value: any) => {
    setEditedItem((prev) => ({ ...prev, [key]: value }));
  };

  const handleSave = async () => {
    try {
      // Ensure the correct ID is sent
      const saveRequest = { ...editedItem, id };
      await updateGearItem({ id, request: saveRequest });
      setIsEditing(false);
    } catch (e) {
      console.error('Failed to save gear item:', e);
      alert('Failed to save changes. Please try again.');
    }
  };

  const handleDeleteConfirm = async () => {
    try {
      await deleteGearItem(id);
      navigation.goBack();
    } catch (e) {
      console.error(e);
    }
  };

  if (isLoading) {
    return (
      <BackgroundComponent>
        <HeaderComponent />
        <View style={styles.center}>
          <Body>Loading...</Body>
        </View>
      </BackgroundComponent>
    );
  }

  if (!gearItem) {
    return (
      <BackgroundComponent>
        <HeaderComponent />
        <View style={styles.center}>
          <Body>Gear item not found.</Body>
        </View>
      </BackgroundComponent>
    );
  }

  return (
    <BackgroundComponent>
      <HeaderComponent />
      <ScrollView contentContainerStyle={styles.container}>
        <View style={styles.header}>
          {isEditing ? (
            <View style={styles.editHeader}>
              <Input
                label="Brand"
                value={editedItem.brand}
                onChangeText={(v) => handleInputChange('brand', v)}
              />
              <Input
                label="Model"
                value={editedItem.model}
                onChangeText={(v) => handleInputChange('model', v)}
              />
              <Dropdown
                label="Category"
                options={getGearCategoryOptions()}
                selectedValue={editedItem.gearCategory}
                onValueChange={(v) => handleInputChange('gearCategory', v)}
              />
            </View>
          ) : (
            <>
              <Heading style={styles.title}>{gearItem.brand}</Heading>
              <Subheading style={styles.subtitle}>
                {gearItem.model || 'Unknown Model'}
              </Subheading>
            </>
          )}
          <View style={styles.badges}>
            <Badge
              label={getGearCategoryLabel(gearItem.gearCategory)}
              backgroundColor={colours.blue}
              color="#fff"
            />
            <Badge
              label={`Tag: #${gearItem.toughTag}`}
              backgroundColor={colours.yellow}
            />
          </View>
        </View>

        <Card style={styles.section}>
          <View style={styles.sectionHeader}>
            <Subheading style={styles.sectionTitle}>General Info</Subheading>
          </View>
          {isEditing ? (
            <>
              <Dropdown
                label="Storage Location"
                options={getStorageLocationOptions()}
                selectedValue={editedItem.storageLocation}
                onValueChange={(v) => handleInputChange('storageLocation', v)}
              />
              <Dropdown
                label="Size"
                options={[{ label: 'None', value: -1 }, ...getSizeOptions()]}
                selectedValue={editedItem.size ?? -1}
                onValueChange={(v) =>
                  handleInputChange('size', v === -1 ? undefined : v)
                }
              />
              <Dropdown
                label="Sex"
                options={[{ label: 'Unisex', value: -1 }, ...getSexOptions()]}
                selectedValue={editedItem.sex ?? -1}
                onValueChange={(v) =>
                  handleInputChange('sex', v === -1 ? undefined : v)
                }
              />
              <Input
                label="Length (m)"
                value={editedItem.length?.toString()}
                keyboardType="numeric"
                onChangeText={(v) => handleInputChange('length', Number(v))}
              />
              <DatePicker
                label="Purchase Date"
                value={editedItem.dateOfPurchase}
                onChange={(v) => handleInputChange('dateOfPurchase', v)}
              />
            </>
          ) : (
            <>
              <InfoRow
                label="Storage Location"
                value={getStorageLocationLabel(gearItem.storageLocation)}
              />
              <InfoRow label="Size" value={getSizeLabel(gearItem.size)} />
              <InfoRow label="Sex" value={getSexLabel(gearItem.sex)} />
              {gearItem.length && (
                <InfoRow label="Length" value={`${gearItem.length}m`} />
              )}
              <InfoRow
                label="Purchase Date"
                value={formatDate(gearItem.dateOfPurchase)}
                last
              />
            </>
          )}
        </Card>

        <Card style={styles.section}>
          <Subheading style={styles.sectionTitle}>
            Inspection Details
          </Subheading>
          {isEditing ? (
            <>
              <DatePicker
                label="Last Inspection"
                value={editedItem.lastInspection}
                onChange={(v) => handleInputChange('lastInspection', v)}
              />
              <DatePicker
                label="Next Inspection"
                value={editedItem.nextInspection}
                onChange={(v) => handleInputChange('nextInspection', v)}
              />
              <DatePicker
                label="Manufacturer Expiry"
                value={editedItem.manufacturerExpiry}
                onChange={(v) => handleInputChange('manufacturerExpiry', v)}
              />
              <Input
                label="Inspected By (User ID)"
                value={editedItem.inspectedBy}
                keyboardType="numeric"
                onChangeText={(v) =>
                  handleInputChange('inspectedBy', v)
                }
              />
            </>
          ) : (
            <>
              <InfoRow
                label="Last Inspection"
                value={formatDate(gearItem.lastInspection)}
              />
              <InfoRow
                label="Next Inspection"
                value={formatDate(gearItem.nextInspection)}
              />
              <InfoRow
                label="Manufacturer Expiry"
                value={formatDate(gearItem.manufacturerExpiry)}
              />
              <InfoRow
                label="Inspected By"
                value={gearItem.inspectedBy || 'N/A'}
                last
              />
            </>
          )}
        </Card>

        <Card style={styles.section}>
          <Subheading style={styles.sectionTitle}>Lending Details</Subheading>
          {isEditing ? (
            <>
              <Input
                label="Lent To (User ID)"
                value={editedItem.lentTo}
                keyboardType="numeric"
                onChangeText={(v) => handleInputChange('lentTo', v)}
              />
              <Input
                label="Lent By (User ID)"
                value={editedItem.lentBy}
                keyboardType="numeric"
                onChangeText={(v) => handleInputChange('lentBy', v)}
              />
              <DatePicker
                label="Lent Date"
                value={editedItem.lentDate}
                onChange={(v) => handleInputChange('lentDate', v)}
              />
              <DatePicker
                label="Returned Date"
                value={editedItem.returnedDate}
                onChange={(v) => handleInputChange('returnedDate', v)}
              />
            </>
          ) : (
            <>
              <InfoRow label="Lent To" value={gearItem.lentTo || 'N/A'} />
              <InfoRow label="Lent By" value={gearItem.lentBy || 'N/A'} />
              <InfoRow
                label="Lent Date"
                value={formatDate(gearItem.lentDate)}
              />
              <InfoRow
                label="Returned Date"
                value={formatDate(gearItem.returnedDate)}
                last
              />
            </>
          )}
        </Card>

        {user?.isAdmin && (
          <View style={styles.actions}>
            {isEditing ? (
              <>
                <Button
                  title="Save Changes"
                  onPress={handleSave}
                  variant="primary"
                />
                <Button
                  title="Cancel"
                  onPress={() => setIsEditing(false)}
                  variant="ghost"
                />
              </>
            ) : (
              <>
                <Button
                  title="Edit Item"
                  variant="secondary"
                  onPress={() => setIsEditing(true)}
                />
                <Button
                  title="Delete Item"
                  variant="danger"
                  onPress={() => setShowDeleteConfirm(true)}
                />
              </>
            )}
          </View>
        )}
      </ScrollView>

      <ConfirmToast
        visible={showDeleteConfirm}
        message="Are you sure you want to delete this item?"
        onConfirm={handleDeleteConfirm}
        onCancel={() => setShowDeleteConfirm(false)}
      />
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  container: {
    padding: spacing.medium,
  },
  center: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  },
  header: {
    marginBottom: spacing.large,
    alignItems: 'center',
  },
  editHeader: {
    width: '100%',
  },
  title: {
    color: '#fff',
    marginBottom: 0,
    textAlign: 'center',
  },
  subtitle: {
    color: '#fff',
    opacity: 0.8,
    textAlign: 'center',
    marginBottom: spacing.small,
  },
  badges: {
    flexDirection: 'row',
    gap: spacing.small,
    marginTop: spacing.small,
  },
  section: {
    marginBottom: spacing.medium,
  },
  sectionHeader: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: spacing.medium,
    borderBottomWidth: 1,
    borderBottomColor: 'rgba(255, 255, 255, 0.2)',
  },
  sectionTitle: {
    color: '#fff',
    fontSize: 16,
    paddingBottom: spacing.xSmall,
    marginBottom: 0,
  },
  actions: {
    marginTop: spacing.large,
    gap: spacing.medium,
    paddingBottom: spacing.xLarge,
  },
});

export default GearItem;
