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
  const [addItemModalVisible, setAddItemModalVisible] = useState(false);
  const [updateItemModalVisible, setUpdateItemModalVisible] = useState(false);
  const [deleteItemModalVisible, setDeleteItemModalVisible] = useState(false);
  const [gearItemId, setGearItemId] = useState(0);

  return (
    <BackgroundComponent>
      <HeaderComponent />
      <View style={styles.items}>
        {gearItems?.map((gi) => (
          <TouchableOpacity key={gi.id} onPress={handleOnPress(gi)}>
            <BubbleComponent style={styles.bubble}>
              <Text>{gi.brand}</Text>
              <View style={styles.options}>
                <TouchableOpacity
                  onPress={() => {
                    setUpdateItemModalVisible(true);
                    setGearItemId(gi.id);
                  }}
                >
                  <BubbleComponent style={styles.bubble}>
                    <Text>Update</Text>
                  </BubbleComponent>
                </TouchableOpacity>
                <TouchableOpacity
                  onPress={() => {
                    setDeleteItemModalVisible(true);
                    setGearItemId(gi.id);
                  }}
                >
                  <BubbleComponent style={styles.bubble}>
                    <Text>Delete</Text>
                  </BubbleComponent>
                </TouchableOpacity>
              </View>
            </BubbleComponent>
          </TouchableOpacity>
        ))}
      </View>
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
  items: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  bubble: {
    padding: 40,
  },
  options: {
    flexDirection: 'row',
  },
});

export default GearItems;
