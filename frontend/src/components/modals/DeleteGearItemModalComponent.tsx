import {
  useAddGearItem,
  useDeleteGearItem,
} from '@api/gear-items/gearItemsApi';
import type { AddGearItemRequest } from '@api/gear-items/gearItemsTypes';
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

const DeleteGearItemModalComponent = ({
  modalVisible,
  setModalVisible,
  gearItemId,
}: {
  modalVisible: boolean;
  setModalVisible: (value: boolean) => void;
  gearItemId: number;
}) => {
  const { mutateAsync: deleteGearItem } = useDeleteGearItem();
  const handleOnPress = async () => {
    try {
      await deleteGearItem(gearItemId);
      setModalVisible(false);
    } catch (e) {
      console.error(e);
    }
  };
  return (
    <Modal visible={modalVisible} transparent={true}>
      <BackgroundComponent>
        <View style={styles.container}>
          <TouchableOpacity onPress={() => handleOnPress()}>
            <BubbleComponent style={styles.bubble}>
              <Text>Delete</Text>
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

export default DeleteGearItemModalComponent;
