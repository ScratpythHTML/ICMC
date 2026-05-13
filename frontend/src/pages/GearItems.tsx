import { useSearchGearItems } from '@api/gear-items/gearItemsApi';
import type { GearItemDto } from '@api/gear-items/gearItemsTypes';
import AddGearItemModalComponent from '@components/modals/AddGearItemModalComponent';
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
import { Card } from '@ui/Card';
import FooterComponent from '@ui/FooterComponent';
import HeaderComponent from '@ui/HeaderComponent';
import { Body, Label, Subheading } from '@ui/Typography';
import {
  getGearCategoryLabel,
  getInspectionStatus,
  getLendingStatus,
  getStorageLocationLabel,
} from '@utils/enumHelpers';
import { AlertCircle, CheckCircle2 } from 'lucide-react-native';
import { useMemo, useState } from 'react';
import { FlatList, StyleSheet, TouchableOpacity, View } from 'react-native';

const GearItems = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const route = useRoute<RouteProp<RootStackParamList, 'GearItems'>>();
  const { user } = useUserContext();
  const { gearCategory, storageLocation } = route.params;
  const { data: gearItems, isLoading } = useSearchGearItems({
    gearCategory,
    storageLocation,
  });

  const [addItemModalVisible, setAddItemModalVisible] = useState(false);

  const stats = useMemo(() => {
    if (!gearItems) return { total: 0, available: 0, needInspection: 0 };
    return gearItems.reduce(
      (acc, item) => {
        acc.total++;
        if (!item.lentToUserId) acc.available++;
        if (item.nextInspection) {
          const today = new Date();
          const inspectionDate = new Date(item.nextInspection);
          const diffTime = inspectionDate.getTime() - today.getTime();
          const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
          if (diffDays <= 30) acc.needInspection++;
        }
        return acc;
      },
      { total: 0, available: 0, needInspection: 0 }
    );
  }, [gearItems]);

  const handleOnPress = (id: number) => {
    navigation.navigate('GearItem', { id });
  };

  const renderItem = ({ item }: { item: GearItemDto }) => {
    const inspectionStatus = getInspectionStatus(item.nextInspection);
    const lendingStatus = getLendingStatus(item.lentToUserId);

    return (
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
            <Badge
              label={`#${item.toughTag}`}
              backgroundColor={colours.yellow}
            />
          </View>

          <View style={styles.cardFooter}>
            <View style={styles.badges}>
              <Badge
                label={getGearCategoryLabel(item.gearCategory)}
                backgroundColor={colours.whiteOpacity}
                color="#fff"
              />
              <Badge
                label={inspectionStatus.label}
                backgroundColor={inspectionStatus.color}
                color="#fff"
              />
              <Badge
                label={lendingStatus.label}
                backgroundColor={lendingStatus.color}
                color="#fff"
              />
            </View>
          </View>
        </Card>
      </TouchableOpacity>
    );
  };

  return (
    <BackgroundComponent>
      <HeaderComponent />
      <View style={styles.header}>
        <Subheading style={styles.headerTitle}>
          {getGearCategoryLabel(gearCategory)}
        </Subheading>
        <Body style={styles.headerSubtitle}>
          {getStorageLocationLabel(storageLocation)}
        </Body>

        <View style={styles.statsRow}>
          <View style={styles.stat}>
            <CheckCircle2 size={16} color={colours.yellow} />
            <Label style={styles.statLabel}>
              {stats.available}/{stats.total} available
            </Label>
          </View>
          <View style={styles.stat}>
            <AlertCircle
              size={16}
              color={stats.needInspection > 0 ? colours.orangeLight : '#fff'}
            />
            <Label
              style={[
                styles.statLabel,
                stats.needInspection > 0 && { color: colours.orangeLight },
              ]}
            >
              {stats.needInspection} need inspection
            </Label>
          </View>
        </View>
      </View>

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
      {user?.isAdmin && (
        <FooterComponent onRightPress={() => setAddItemModalVisible(true)} />
      )}
      <AddGearItemModalComponent
        modalVisible={addItemModalVisible}
        setModalVisible={setAddItemModalVisible}
      />
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  header: {
    padding: spacing.medium,
    alignItems: 'center',
    borderBottomWidth: 1,
    borderBottomColor: 'rgba(255, 255, 255, 0.1)',
  },
  headerTitle: {
    color: '#fff',
    marginBottom: 0,
  },
  headerSubtitle: {
    color: '#fff',
    opacity: 0.7,
    fontSize: 14,
    marginBottom: spacing.small,
  },
  statsRow: {
    flexDirection: 'row',
    gap: spacing.large,
    marginTop: spacing.xSmall,
  },
  stat: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing.xSmall,
  },
  statLabel: {
    color: 'rgba(255, 255, 255, 0.8)',
    marginBottom: 0,
    fontSize: 14,
    fontWeight: '600',
  },
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
  badges: {
    flexDirection: 'row',
    flexWrap: 'wrap',
    gap: spacing.xSmall,
  },
  emptyContainer: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    paddingTop: 100,
  },
});

export default GearItems;
