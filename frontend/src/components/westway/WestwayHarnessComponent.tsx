import { useGetHarness } from '@api/harnesses/harnessesApi';
import type { RootStackParamList } from '@navigation/BootRouter';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import { Text, View } from 'react-native';
import type { NativeStackScreenProps } from 'react-native-screens/lib/typescript/native-stack/types';

type Props = NativeStackScreenProps<
  RootStackParamList,
  'WestwayHarnessComponent'
>;

const WestwayHarnessComponent = ({ route }: Props) => {
  const { id } = route.params;
  const { data: harness } = useGetHarness(id);
  return (
    <BackgroundComponent>
      <BubbleComponent>
        <View>
          <Text>{harness?.brand}</Text>
          <Text>{harness?.id}</Text>
          <Text>{harness?.dateOfPurchase}</Text>
          <Text>{harness?.inspectedBy}</Text>
          <Text>{harness?.lastInspection}</Text>
          <Text>{harness?.lentBy}</Text>
          <Text>{harness?.lentTo}</Text>
          <Text>{harness?.manufacturerExpiry}</Text>
          <Text>{harness?.model}</Text>
          <Text>{harness?.nextInspection}</Text>
          <Text>{harness?.returnedDate}</Text>
          <Text>{harness?.storageLocation}</Text>
          <Text>{harness?.toughTag}</Text>
          <Text>{harness?.size}</Text>
          <Text>{harness?.sex}</Text>
        </View>
      </BubbleComponent>
    </BackgroundComponent>
  );
};

export default WestwayHarnessComponent;
