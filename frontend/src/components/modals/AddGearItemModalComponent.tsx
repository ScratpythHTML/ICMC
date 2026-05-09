import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import { Modal, Text, TouchableOpacity } from 'react-native';

const AddGearItemModalComponent = ({
  modalVisible,
  setModalVisible,
}: {
  modalVisible: boolean;
  setModalVisible: (value: boolean) => void;
}) => {
  return (
    <Modal visible={modalVisible} transparent={true}>
      <BackgroundComponent>
        <TouchableOpacity onPress={() => setModalVisible(false)}>
          <BubbleComponent>
            <Text>Close</Text>
          </BubbleComponent>
        </TouchableOpacity>
      </BackgroundComponent>
    </Modal>
  );
};

export default AddGearItemModalComponent;
