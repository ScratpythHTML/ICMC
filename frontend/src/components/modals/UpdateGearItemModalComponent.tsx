import {
  useAddGearItem,
  useUpdateGearItem,
} from '@api/gear-items/gearItemsApi';
import type {
  AddGearItemRequest,
  UpdateGearItemRequest,
} from '@api/gear-items/gearItemsTypes';
import type { RootStackParamList } from '@navigation/BootRouter';
import { type RouteProp, useRoute } from '@react-navigation/native';
import { borderRadius, colours } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import { useRef } from 'react';
import {
  Modal,
  StyleSheet,
  Text,
  TextInput,
  TouchableOpacity,
  View,
} from 'react-native';

const UpdateGearItemModalComponent = ({
  modalVisible,
  setModalVisible,
  gearItemId,
}: {
  modalVisible: boolean;
  setModalVisible: (value: boolean) => void;
  gearItemId: number;
}) => {
  const route = useRoute<RouteProp<RootStackParamList, 'GearItems'>>();
  const { gearCategory, storageLocation } = route.params;
  const toughTagRef = useRef<string>('');
  const { mutateAsync: updateGearItem } = useUpdateGearItem();
  const handleChangeText = (value: string) => {
    toughTagRef.current = value;
  };
  console.log(gearItemId);
  const handleOnPress = async () => {
    const request: UpdateGearItemRequest = {
      id: gearItemId,
      toughTag: Number(toughTagRef.current),
      gearCategory: gearCategory,
      storageLocation: storageLocation,
    };
    try {
      await updateGearItem({ id: gearItemId, request });
      setModalVisible(false);
    } catch (e) {
      console.error(e);
    }
  };
  return (
    <Modal visible={modalVisible} transparent={true}>
      <BackgroundComponent>
        <View style={styles.container}>
          <Text>ToughTag:</Text>
          <TextInput
            style={styles.passwordInputCard}
            placeholder="e.g. 112"
            placeholderTextColor={colours.black}
            onChangeText={handleChangeText}
          />
        </View>
        <View style={styles.container}>
          <TouchableOpacity onPress={() => handleOnPress()}>
            <BubbleComponent style={styles.bubble}>
              <Text>Submit</Text>
            </BubbleComponent>
          </TouchableOpacity>
          <TouchableOpacity onPress={() => setModalVisible(false)}>
            <BubbleComponent style={styles.bubble}>
              <Text>Close</Text>
            </BubbleComponent>
          </TouchableOpacity>
        </View>
      </BackgroundComponent>
    </Modal>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: 'row',
    justifyContent: 'center',
    alignItems: 'center',
    gap: 20,
  },
  passwordInputCard: {
    borderRadius: borderRadius.xxLarge,
    borderWidth: 2,
    padding: 20,
    borderColor: colours.orangeDark,
  },
  loginButton: {
    borderWidth: 2,
    padding: 20,
    borderRadius: borderRadius.xxLarge,
  },
  bubble: {
    padding: 40,
  },
});

export default UpdateGearItemModalComponent;
