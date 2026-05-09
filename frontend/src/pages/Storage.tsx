import { GearCategory } from '@api/common/enums';
import type { RootStackParamList } from '@navigation/BootRouter';
import {
  type NavigationProp,
  type RouteProp,
  useNavigation,
  useRoute,
} from '@react-navigation/native';
import { spacing } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { Card } from '@ui/Card';
import HeaderComponent from '@ui/HeaderComponent';
import { Body, Heading } from '@ui/Typography';
import {
  getGearCategoryLabel,
  getStorageLocationLabel,
} from '@utils/enumHelpers';
import { ChevronRight } from 'lucide-react-native';
import { FlatList, StyleSheet, TouchableOpacity, View } from 'react-native';

const Storage = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const route = useRoute<RouteProp<RootStackParamList, 'Storage'>>();
  const { storageLocation } = route.params;

  const gearCategories = Object.values(GearCategory).filter(
    (v) => typeof v === 'number'
  ) as GearCategory[];

  const handleOnPress = (gc: GearCategory) => {
    navigation.navigate('GearItems', {
      gearCategory: gc,
      storageLocation: storageLocation,
    });
  };

  const renderItem = ({ item }: { item: GearCategory }) => (
    <TouchableOpacity onPress={() => handleOnPress(item)} activeOpacity={0.7}>
      <Card style={styles.card}>
        <View style={styles.cardContent}>
          <Body style={styles.categoryName}>{getGearCategoryLabel(item)}</Body>
          <ChevronRight size={20} color="rgba(255, 255, 255, 0.5)" />
        </View>
      </Card>
    </TouchableOpacity>
  );

  return (
    <BackgroundComponent>
      <HeaderComponent />
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
  categoryName: {
    color: '#fff',
    fontSize: 18,
  },
});

export default Storage;
