import { useGetGearItems } from '@api/gear-items/gearItemsApi';
import type { GearItemDto } from '@api/gear-items/gearItemsTypes';
import AddGearItemModalComponent from '@components/modals/AddGearItemModalComponent';
import DeleteGearItemModalComponent from '@components/modals/DeleteGearItemModalComponent';
import UpdateGearItemModalComponent from '@components/modals/UpdateGearItemModalComponent';
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
import { Card } from '@ui/Card';
import FooterComponent from '@ui/FooterComponent';
import HeaderComponent from '@ui/HeaderComponent';
import { Body, Subheading } from '@ui/Typography';
import { getGearCategoryLabel } from '@utils/enumHelpers';
import { Edit2, Trash2 } from 'lucide-react-native';
import { useState } from 'react';
import { FlatList, StyleSheet, TouchableOpacity, View } from 'react-native';

const GearItems = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const route = useRoute<RouteProp<RootStackParamList, 'GearItems'>>();
  const { gearCategory, storageLocation } = route.params;
  const { data: gearItems, isLoading } = useGetGearItems({
    gearCategory,
    storageLocation,
  });

  const [addItemModalVisible, setAddItemModalVisible] = useState(false);
  const [updateItemModalVisible, setUpdateItemModalVisible] = useState(false);
  const [deleteItemModalVisible, setDeleteItemModalVisible] = useState(false);
  const [gearItemId, setGearItemId] = useState(0);

  const handleOnPress = (id: number) => {
    navigation.navigate('GearItem', { id });
  };

  const renderItem = ({ item }: { item: GearItemDto }) => (
    <TouchableOpacity
      onPress={() => handleOnPress(item.id)}
      activeOpacity={0.7}
    >
      <Card style={styles.card}>
        <View style={styles.cardHeader}>
          <View style={styles.titleContainer}>
            <Subheading style={styles.brand}>{item.brand}</Subheading>
            <Body style={styles.model}>{item.model || 'Unknown Model'}</Body>
          </View>
          <Badge label={`#${item.toughTag}`} backgroundColor={colours.yellow} />
        </View>

        <View style={styles.cardFooter}>
          <Badge
            label={getGearCategoryLabel(item.gearCategory)}
            backgroundColor={colours.whiteOpacity}
            color={
              colours.whiteOpacity === 'rgba(255, 255, 255, 0.05)'
                ? '#fff'
                : colours.black
            }
          />
          <View style={styles.actions}>
            <TouchableOpacity
              onPress={() => {
                setGearItemId(item.id);
                setUpdateItemModalVisible(true);
              }}
              style={styles.actionButton}
            >
              <Edit2 size={18} color={colours.blue} />
            </TouchableOpacity>
            <TouchableOpacity
              onPress={() => {
                setGearItemId(item.id);
                setDeleteItemModalVisible(true);
              }}
              style={styles.actionButton}
            >
              <Trash2 size={18} color={colours.purpleLight} />
            </TouchableOpacity>
          </View>
        </View>
      </Card>
    </TouchableOpacity>
  );

  return (
    <BackgroundComponent>
      <HeaderComponent />
      <FlatList
        data={gearItems}
        renderItem={renderItem}
        keyExtractor={(item) => item.id.toString()}
        contentContainerStyle={styles.listContent}
        ListEmptyComponent={
          !isLoading ? (
            <View style={styles.emptyContainer}>
              <Body>No gear items found.</Body>
            </View>
          ) : null
        }
      />
      <FooterComponent onRightPress={() => setAddItemModalVisible(true)} />
      <UpdateGearItemModalComponent
        modalVisible={updateItemModalVisible}
        setModalVisible={setUpdateItemModalVisible}
        gearItemId={gearItemId}
      />
      <DeleteGearItemModalComponent
        modalVisible={deleteItemModalVisible}
        setModalVisible={setDeleteItemModalVisible}
        gearItemId={gearItemId}
      />
      <AddGearItemModalComponent
        modalVisible={addItemModalVisible}
        setModalVisible={setAddItemModalVisible}
      />
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  listContent: {
    padding: spacing.medium,
    gap: spacing.medium,
  },
  card: {
    marginBottom: spacing.small,
  },
  cardHeader: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'flex-start',
    marginBottom: spacing.medium,
  },
  titleContainer: {
    flex: 1,
    marginRight: spacing.small,
  },
  brand: {
    marginBottom: 0,
    color: '#fff',
  },
  model: {
    opacity: 0.8,
    color: '#fff',
  },
  cardFooter: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginTop: spacing.small,
  },
  actions: {
    flexDirection: 'row',
    gap: spacing.medium,
  },
  actionButton: {
    padding: spacing.xSmall,
  },
  emptyContainer: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    paddingTop: 100,
  },
});

export default GearItems;
