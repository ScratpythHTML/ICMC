import { useGetGearItems } from '@api/gear-items/gearItemsApi';
import type { GearItemDto } from '@api/gear-items/gearItemsTypes';
import AddGearItemModalComponent from '@components/modals/AddGearItemModalComponent';
import type { RootStackParamList } from '@navigation/BootRouter';
import {
  type NavigationProp,
  type RouteProp,
  useNavigation,
  useRoute,
} from '@react-navigation/native';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import FooterComponent from '@ui/FooterComponent';
import HeaderComponent from '@ui/HeaderComponent';
import { useState } from 'react';
import { StyleSheet, Text, TouchableOpacity, View } from 'react-native';

const GearItems = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const route = useRoute<RouteProp<RootStackParamList, 'GearItems'>>();
  const { gearCategory, storageLocation } = route.params;
  const { data: gearItems } = useGetGearItems({
    gearCategory,
    storageLocation,
  });
  const handleOnPress = (gi: GearItemDto) => () => {
    navigation.navigate('GearItem', { id: gi.id });
  };
  const [modalVisible, setModalVisible] = useState(false);

  return (
    <BackgroundComponent>
      <HeaderComponent />
      <View style={styles.items}>
        {gearItems?.map((gi) => (
          <TouchableOpacity key={gi.id} onPress={handleOnPress(gi)}>
            <BubbleComponent style={styles.bubble}>
              <Text>{gi.brand}</Text>
            </BubbleComponent>
          </TouchableOpacity>
        ))}
      </View>
      <FooterComponent onRightPress={() => setModalVisible(true)} />
      <AddGearItemModalComponent
        modalVisible={modalVisible}
        setModalVisible={setModalVisible}
      />
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  items: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  bubble: {
    padding: 40,
  },
});

export default GearItems;
