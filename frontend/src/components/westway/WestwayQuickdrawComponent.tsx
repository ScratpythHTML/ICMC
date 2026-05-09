import { useGetQuickdraw } from '@api/quickdraws/quickdrawsApi';
import type { RootStackParamList } from '@navigation/BootRouter';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import { Text, View } from 'react-native';
import type { NativeStackScreenProps } from 'react-native-screens/lib/typescript/native-stack/types';

type Props = NativeStackScreenProps<
  RootStackParamList,
  'WestwayQuickdrawComponent'
>;

const WestwayQuickdrawComponent = ({ route }: Props) => {
  const { id } = route.params;
  const { data: quickdraw } = useGetQuickdraw(id);
  return (
    <BackgroundComponent>
      <BubbleComponent>
        <View>
          <Text>{quickdraw?.brand}</Text>
          <Text>{quickdraw?.id}</Text>
          <Text>{quickdraw?.dateOfPurchase}</Text>
          <Text>{quickdraw?.inspectedBy}</Text>
          <Text>{quickdraw?.lastInspection}</Text>
          <Text>{quickdraw?.lentBy}</Text>
          <Text>{quickdraw?.lentTo}</Text>
          <Text>{quickdraw?.manufacturerExpiry}</Text>
          <Text>{quickdraw?.model}</Text>
          <Text>{quickdraw?.nextInspection}</Text>
          <Text>{quickdraw?.returnedDate}</Text>
          <Text>{quickdraw?.storageLocation}</Text>
          <Text>{quickdraw?.toughTag}</Text>
        </View>
      </BubbleComponent>
    </BackgroundComponent>
  );
};

export default WestwayQuickdrawComponent;
