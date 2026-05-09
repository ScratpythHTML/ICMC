import { useGetCrashpad } from '@api/crashpads/crashpadsApi';
import type { RootStackParamList } from '@navigation/BootRouter';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import { Text, View } from 'react-native';
import type { NativeStackScreenProps } from 'react-native-screens/lib/typescript/native-stack/types';

type Props = NativeStackScreenProps<
  RootStackParamList,
  'WestwayCrashpadComponent'
>;

const WestwayCrashpadComponent = ({ route }: Props) => {
  const { id } = route.params;
  const { data: crashpad } = useGetCrashpad(id);
  return (
    <BackgroundComponent>
      <BubbleComponent>
        <View>
          <Text>{crashpad?.brand}</Text>
          <Text>{crashpad?.id}</Text>
          <Text>{crashpad?.dateOfPurchase}</Text>
          <Text>{crashpad?.inspectedBy}</Text>
          <Text>{crashpad?.lastInspection}</Text>
          <Text>{crashpad?.lentBy}</Text>
          <Text>{crashpad?.lentTo}</Text>
          <Text>{crashpad?.manufacturerExpiry}</Text>
          <Text>{crashpad?.model}</Text>
          <Text>{crashpad?.nextInspection}</Text>
          <Text>{crashpad?.returnedDate}</Text>
          <Text>{crashpad?.storageLocation}</Text>
          <Text>{crashpad?.toughTag}</Text>
        </View>
      </BubbleComponent>
    </BackgroundComponent>
  );
};

export default WestwayCrashpadComponent;
