import { colours, spacing, borderRadius, fonts } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import HeaderComponent from '@ui/HeaderComponent';
import { Body, Heading, Label } from '@ui/Typography';
import { StyleSheet, View, TextInput, TouchableOpacity, ActivityIndicator } from 'react-native';
import { useSearchGearItems } from '@api/gear-items/gearItemsApi';
import { useState, useMemo, useEffect } from 'react';
import { Search, SlidersHorizontal, Package } from 'lucide-react-native';
import { FlatList } from 'react-native';
import { Card } from '@ui/Card';
import FilterGearModal from '@components/modals/FilterGearModal';
import { GearCategory, Sex, Size, StorageLocation } from '@api/common/enums';
import { useNavigation, type NavigationProp } from '@react-navigation/native';
import type { RootStackParamList } from '@navigation/BootRouter';
import { getGearCategoryLabel, getGearCategoryColor } from '@utils/enumHelpers';

const Browse = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const [search, setSearch] = useState('');
  const [debouncedSearch, setDebouncedSearch] = useState('');
  const [isFilterModalVisible, setIsFilterModalVisible] = useState(false);
  const [filters, setFilters] = useState<{ 
    gearCategory?: GearCategory;
    sex?: Sex;
    size?: Size;
    storageLocation?: StorageLocation;
  }>({});

  // Debounce search term to update as you type
  useEffect(() => {
    const handler = setTimeout(() => {
      setDebouncedSearch(search);
    }, 400); // Slightly longer debounce for better UX

    return () => {
      clearTimeout(handler);
    };
  }, [search]);

  const { data: gearItems, isLoading, isFetching } = useSearchGearItems({ 
    search: debouncedSearch, 
    ...filters
  });

  const isFilterActive = useMemo(() => {
    return Object.values(filters).some(v => v !== undefined);
  }, [filters]);

  const renderItem = ({ item }: { item: any }) => (
    <TouchableOpacity 
      style={styles.cardItem}
      onPress={() => navigation.navigate('GearItem', { id: item.id })}
    >
      <Card style={styles.card}>
        <View style={styles.cardHeader}>
          <View style={styles.iconContainer}>
            <Package size={20} color={getGearCategoryColor(item.gearCategory)} />
          </View>
          <View style={styles.cardTitleContainer}>
            <View style={styles.titleBadgeRow}>
              <Body style={styles.brandText}>{item.brand}</Body>
              <View style={[styles.categoryBadge, { backgroundColor: getGearCategoryColor(item.gearCategory) + '20' }]}>
                <Label style={[styles.categoryText, { color: getGearCategoryColor(item.gearCategory) }]}>
                  {getGearCategoryLabel(item.gearCategory)}
                </Label>
              </View>
            </View>
            <Label style={styles.modelText}>{item.model || 'Unknown Model'}</Label>
          </View>
          <View style={styles.tagBadge}>
            <Label style={styles.tagText}>#{item.toughTag}</Label>
          </View>
        </View>
      </Card>
    </TouchableOpacity>
  );

  return (
    <BackgroundComponent>
      <HeaderComponent />
      <View style={styles.container}>
        <View style={styles.titleRow}>
          <Heading>Browse Gear</Heading>
          {(isFetching && !isLoading) && <ActivityIndicator color={colours.blue} size="small" />}
        </View>
        
        <View style={styles.searchRow}>
          <View style={styles.searchBar}>
            <Search size={20} color={colours.textMuted} />
            <TextInput
              style={styles.input}
              placeholder="Search Gear..."
              placeholderTextColor={colours.textMuted}
              value={search}
              onChangeText={setSearch}
              keyboardAppearance="dark"
            />
          </View>
          <TouchableOpacity 
            activeOpacity={1}
            style={[
              styles.filterButton, 
              isFilterActive && styles.filterButtonActive
            ]}
            onPress={() => setIsFilterModalVisible(true)}
          >
            <SlidersHorizontal 
              size={20} 
              color={isFilterActive ? colours.blue : "#fff"} 
            />
          </TouchableOpacity>
        </View>

        {isLoading ? (
          <View style={styles.center}>
            <ActivityIndicator color={colours.blue} size="large" />
          </View>
        ) : (
          <FlatList
            data={gearItems}
            renderItem={renderItem}
            keyExtractor={(item) => item.id.toString()}
            contentContainerStyle={styles.list}
            numColumns={1}
            ListEmptyComponent={
              <View style={styles.empty}>
                <Body color={colours.textMuted}>
                  {isFetching ? 'Searching...' : 'No items found'}
                </Body>
              </View>
            }
          />
        )}
      </View>

      <FilterGearModal
        visible={isFilterModalVisible}
        onClose={() => setIsFilterModalVisible(false)}
        filters={filters}
        onApply={setFilters}
      />
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: spacing.medium,
  },
  titleRow: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginBottom: spacing.small,
  },
  searchRow: {
    flexDirection: 'row',
    gap: spacing.small,
    marginVertical: spacing.medium,
    marginTop: 0,
  },
  searchBar: {
    flex: 1,
    flexDirection: 'row',
    alignItems: 'center',
    backgroundColor: colours.surface,
    borderRadius: borderRadius.medium,
    paddingHorizontal: spacing.medium,
    height: 50,
    gap: spacing.small,
    borderWidth: 1,
    borderColor: colours.whiteOpacity,
  },
  input: {
    flex: 1,
    color: colours.textPrimary,
    fontSize: 16,
    fontFamily: fonts.regular,
  },
  filterButton: {
    width: 50,
    height: 50,
    backgroundColor: colours.surface,
    borderRadius: borderRadius.medium,
    alignItems: 'center',
    justifyContent: 'center',
    borderWidth: 1,
    borderColor: colours.whiteOpacity,
  },
  filterButtonActive: {
    borderColor: colours.blue,
  },
  list: {
    gap: spacing.small,
    paddingBottom: spacing.xxxLarge,
  },
  cardItem: {
    marginBottom: spacing.small,
  },
  card: {
    padding: spacing.small,
  },
  cardHeader: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing.medium,
  },
  iconContainer: {
    width: 40,
    height: 40,
    borderRadius: 10,
    backgroundColor: colours.surfaceLight,
    alignItems: 'center',
    justifyContent: 'center',
  },
  cardTitleContainer: {
    flex: 1,
  },
  titleBadgeRow: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing.small,
  },
  brandText: {
    fontWeight: '700',
    color: colours.textPrimary,
  },
  categoryBadge: {
    paddingHorizontal: 6,
    paddingVertical: 2,
    borderRadius: 4,
  },
  categoryText: {
    fontSize: 9,
    fontWeight: '700',
    textTransform: 'uppercase',
  },
  modelText: {
    fontSize: 12,
  },
  tagBadge: {
    backgroundColor: colours.whiteOpacityStrong,
    paddingHorizontal: spacing.small,
    paddingVertical: 4,
    borderRadius: 6,
  },
  tagText: {
    fontSize: 10,
    fontWeight: '700',
  },
  center: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  },
  empty: {
    alignItems: 'center',
    marginTop: spacing.xxLarge,
  }
});

export default Browse;
