import { useGetGearItem } from '@api/gear-items/gearItemsApi';
import type { RootStackParamList } from '@navigation/BootRouter';
import { type RouteProp, useRoute } from '@react-navigation/native';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import HeaderComponent from '@ui/HeaderComponent';
import { View } from 'react-native';

const GearItem = () => {
  const route = useRoute<RouteProp<RootStackParamList, 'GearItem'>>();
  const { id } = route.params;
  const { data: gearItem } = useGetGearItem(id);
  return (
    <BackgroundComponent>
      <HeaderComponent />
      <View>
        <BubbleComponent>{gearItem?.brand}</BubbleComponent>
      </View>
    </BackgroundComponent>
  );
};

export default GearItem;
