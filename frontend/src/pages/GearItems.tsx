import { useGetGearItems } from '@api/gear-items/gearItemsApi';
import type { GearItemDto } from '@api/gear-items/gearItemsTypes';
import type { RootStackParamList } from '@navigation/BootRouter';
import {
  type NavigationProp,
  type RouteProp,
  useNavigation,
  useRoute,
} from '@react-navigation/native';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import HeaderComponent from '@ui/HeaderComponent';
import { Text, TouchableOpacity, View } from 'react-native';

const GearItems = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const route = useRoute<RouteProp<RootStackParamList, 'GearItems'>>();
  const { gearCategory, storageLocation } = route.params;
  const { data: gearItems } = useGetGearItems({
    gearCategory,
    storageLocation,
  });
  const handleOnPress = (gi: GearItemDto) => {
    navigation.navigate('GearItem', { id: gi.id });
  };

  return (
    <BackgroundComponent>
      <HeaderComponent />
      <View>
        {gearItems?.map((gi) => (
          <TouchableOpacity key={gi.id} onPress={() => handleOnPress}>
            <BubbleComponent>
              <Text>{gi.brand}</Text>
            </BubbleComponent>
          </TouchableOpacity>
        ))}
      </View>
    </BackgroundComponent>
  );
};

export default GearItems;
