import { GearCategory } from '@api/common/enums';
import type { RootStackParamList } from '@navigation/BootRouter';
import {
  type NavigationProp,
  type RouteProp,
  useNavigation,
  useRoute,
} from '@react-navigation/native';
import { fonts } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import HeaderComponent from '@ui/HeaderComponent';
import { StyleSheet, Text, TouchableOpacity, View } from 'react-native';

const Storage = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const route = useRoute<RouteProp<RootStackParamList, 'Storage'>>();
  const { storageLocation } = route.params;

  const gearCategories = Object.values(GearCategory).filter(
    (v) => typeof v === 'number'
  );

  const handleOnPress = (gc: GearCategory) => () => {
    navigation.navigate('GearItems', {
      gearCategory: gc,
      storageLocation: storageLocation,
    });
  };

  return (
    <BackgroundComponent>
      <HeaderComponent />
      <View>
        <Text style={styles.title}>{storageLocation}</Text>
        {gearCategories.map((gc) => (
          <TouchableOpacity key={gc} onPress={handleOnPress(gc)}>
            <BubbleComponent>
              <Text>{GearCategory[gc]}</Text>
            </BubbleComponent>
          </TouchableOpacity>
        ))}
      </View>
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  container: {
    padding: 20,
    gap: 20,
  },
  bubble: {
    padding: 20,
    alignItems: 'center',
  },
  title: {
    fontSize: fonts.sizeLarge,
  },
});
export default Storage;
