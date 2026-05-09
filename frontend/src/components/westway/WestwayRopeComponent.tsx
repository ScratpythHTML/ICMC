import { useGetRope } from '@api/ropes/ropesApi';
import type { RootStackParamList } from '@navigation/BootRouter';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import { Text, View } from 'react-native';
import type { NativeStackScreenProps } from 'react-native-screens/lib/typescript/native-stack/types';

type Props = NativeStackScreenProps<
  RootStackParamList,
  'WestwayRopeComponent'
>;

const WestwayRopeComponent = ({ route }: Props) => {
  const { id } = route.params;
  const { data: rope } = useGetRope(id);
  return (
    <BackgroundComponent>
      <BubbleComponent>
        <View>
          <Text>{rope?.brand}</Text>
          <Text>{rope?.id}</Text>
          <Text>{rope?.dateOfPurchase}</Text>
          <Text>{rope?.inspectedBy}</Text>
          <Text>{rope?.lastInspection}</Text>
          <Text>{rope?.lentBy}</Text>
          <Text>{rope?.lentTo}</Text>
          <Text>{rope?.manufacturerExpiry}</Text>
          <Text>{rope?.model}</Text>
          <Text>{rope?.nextInspection}</Text>
          <Text>{rope?.returnedDate}</Text>
          <Text>{rope?.storageLocation}</Text>
          <Text>{rope?.toughTag}</Text>
          <Text>{rope?.length}</Text>
        </View>
      </BubbleComponent>
    </BackgroundComponent>
  );
};

export default WestwayRopeComponent;
