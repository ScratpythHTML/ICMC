import { GearCategory } from '@api/common/enums';
import { useSearchGearItems } from '@api/gear-items/gearItemsApi';
import type { RootStackParamList } from '@navigation/BootRouter';
import {
  type NavigationProp,
  type RouteProp,
  useNavigation,
  useRoute,
} from '@react-navigation/native';
import { colours, spacing } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { Card } from '@ui/Card';
import { Body, Heading, Label } from '@ui/Typography';
import {
  getGearCategoryLabel,
  getStorageLocationLabel,
} from '@utils/enumHelpers';
import { AlertCircle, CheckCircle2, ChevronRight } from 'lucide-react-native';
import { useMemo } from 'react';
import { FlatList, StyleSheet, TouchableOpacity, View } from 'react-native';

const Storage = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const route = useRoute<RouteProp<RootStackParamList, 'Storage'>>();
  const { storageLocation } = route.params;

  const { data: allItems } = useSearchGearItems({ storageLocation });

  const gearCategories = Object.values(GearCategory).filter(
    (v) => typeof v === 'number'
  ) as GearCategory[];

  const categoryStats = useMemo(() => {
    const stats: Record<
      number,
      { total: number; available: number; needInspection: number }
    > = {};

    for (const cat of gearCategories) {
      stats[cat] = { total: 0, available: 0, needInspection: 0 };
    }

    if (allItems) {
      for (const item of allItems) {
        const cat = item.gearCategory;
        if (stats[cat]) {
          stats[cat].total++;
          if (!item.lentToUserId) {
            stats[cat].available++;
          }

          if (item.nextInspection) {
            const today = new Date();
            const inspectionDate = new Date(item.nextInspection);
            const diffTime = inspectionDate.getTime() - today.getTime();
            const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
            if (diffDays <= 30) {
              stats[cat].needInspection++;
            }
          }
        }
      }
    }
    return stats;
  }, [allItems, gearCategories]);

  const handleOnPress = (gc: GearCategory) => {
    navigation.navigate('GearItems', {
      gearCategory: gc,
      storageLocation: storageLocation,
    });
  };

  const renderItem = ({ item }: { item: GearCategory }) => {
    const stats = categoryStats[item];
    return (
      <TouchableOpacity onPress={() => handleOnPress(item)} activeOpacity={0.7}>
        <Card style={styles.card}>
          <View style={styles.cardContent}>
            <View style={styles.infoContainer}>
              <Body style={styles.categoryName}>
                {getGearCategoryLabel(item)}
              </Body>
              <View style={styles.statsRow}>
                <View style={styles.stat}>
                  <CheckCircle2 size={14} color={colours.yellow} />
                  <Label style={styles.statLabel}>
                    {stats.available}/{stats.total} available
                  </Label>
                </View>
                <View style={styles.stat}>
                  <AlertCircle
                    size={14}
                    color={
                      stats.needInspection > 0 ? colours.orangeLight : '#fff'
                    }
                  />
                  <Label
                    style={[
                      styles.statLabel,
                      stats.needInspection > 0 && {
                        color: colours.orangeLight,
                      },
                    ]}
                  >
                    {stats.needInspection} need inspection
                  </Label>
                </View>
              </View>
            </View>
            <ChevronRight size={20} color="rgba(255, 255, 255, 0.5)" />
          </View>
        </Card>
      </TouchableOpacity>
    );
  };

  return (
    <BackgroundComponent>
      <View style={styles.header}>
        <Heading style={styles.title}>
          {getStorageLocationLabel(storageLocation)}
        </Heading>
        <Body style={styles.subtitle}>Select a category</Body>
      </View>
      <FlatList
        data={gearCategories}
        renderItem={renderItem}
        keyExtractor={(item) => item.toString()}
        contentContainerStyle={styles.listContent}
      />
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  header: {
    padding: spacing.medium,
    alignItems: 'center',
    marginBottom: spacing.small,
  },
  title: {
    color: '#fff',
    marginBottom: 0,
  },
  subtitle: {
    color: '#fff',
    opacity: 0.7,
  },
  listContent: {
    padding: spacing.medium,
    gap: spacing.small,
  },
  card: {
    marginBottom: spacing.xSmall,
  },
  cardContent: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    paddingVertical: spacing.xSmall,
  },
  infoContainer: {
    flex: 1,
  },
  categoryName: {
    color: '#fff',
    fontSize: 18,
    fontWeight: '600',
    marginBottom: spacing.xSmall,
  },
  statsRow: {
    flexDirection: 'row',
    gap: spacing.medium,
  },
  stat: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing.xxSmall,
  },
  statLabel: {
    color: 'rgba(255, 255, 255, 0.6)',
    marginBottom: 0,
    fontSize: 12,
  },
});

export default Storage;