import { useGetHelmet } from '@api/helmets/helmetsApi';
import type { RootStackParamList } from '@navigation/BootRouter';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import { Text, View } from 'react-native';
import type { NativeStackScreenProps } from 'react-native-screens/lib/typescript/native-stack/types';

type Props = NativeStackScreenProps<
  RootStackParamList,
  'WestwayHelmetComponent'
>;

const WestwayHelmetComponent = ({ route }: Props) => {
  const { id } = route.params;
  const { data: helmet } = useGetHelmet(id);
  return (
    <BackgroundComponent>
      <BubbleComponent>
        <View>
          <Text>{helmet?.brand}</Text>
          <Text>{helmet?.id}</Text>
          <Text>{helmet?.dateOfPurchase}</Text>
          <Text>{helmet?.inspectedBy}</Text>
          <Text>{helmet?.lastInspection}</Text>
          <Text>{helmet?.lentBy}</Text>
          <Text>{helmet?.lentTo}</Text>
          <Text>{helmet?.manufacturerExpiry}</Text>
          <Text>{helmet?.model}</Text>
          <Text>{helmet?.nextInspection}</Text>
          <Text>{helmet?.returnedDate}</Text>
          <Text>{helmet?.storageLocation}</Text>
          <Text>{helmet?.toughTag}</Text>
          <Text>{helmet?.size}</Text>
        </View>
      </BubbleComponent>
    </BackgroundComponent>
  );
};

export default WestwayHelmetComponent;
