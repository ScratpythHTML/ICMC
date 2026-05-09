import { useGetBelayDevice } from '@api/belay-devices/belayDevicesApi';
import type { RootStackParamList } from '@navigation/BootRouter';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import { Text, View } from 'react-native';
import type { NativeStackScreenProps } from 'react-native-screens/lib/typescript/native-stack/types';

type Props = NativeStackScreenProps<
  RootStackParamList,
  'ImperialBelayDeviceComponent'
>;

const ImperialBelayDeviceComponent = ({ route }: Props) => {
  const { id } = route.params;
  const { data: belayDevice } = useGetBelayDevice(id);
  return (
    <BackgroundComponent>
      <BubbleComponent>
        <View>
          <Text>{belayDevice?.brand}</Text>
          <Text>{belayDevice?.id}</Text>
          <Text>{belayDevice?.dateOfPurchase}</Text>
          <Text>{belayDevice?.inspectedBy}</Text>
          <Text>{belayDevice?.lastInspection}</Text>
          <Text>{belayDevice?.lentBy}</Text>
          <Text>{belayDevice?.lentTo}</Text>
          <Text>{belayDevice?.manufacturerExpiry}</Text>
          <Text>{belayDevice?.model}</Text>
          <Text>{belayDevice?.nextInspection}</Text>
          <Text>{belayDevice?.returnedDate}</Text>
          <Text>{belayDevice?.storageLocation}</Text>
          <Text>{belayDevice?.toughTag}</Text>
        </View>
      </BubbleComponent>
    </BackgroundComponent>
  );
};

export default ImperialBelayDeviceComponent;
