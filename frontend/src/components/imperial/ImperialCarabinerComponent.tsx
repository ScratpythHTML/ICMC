import { useGetCarabiner } from '@api/carabiners/carabinersApi';
import type { RootStackParamList } from '@navigation/BootRouter';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import { Text, View } from 'react-native';
import type { NativeStackScreenProps } from 'react-native-screens/lib/typescript/native-stack/types';

type Props = NativeStackScreenProps<
  RootStackParamList,
  'ImperialCarabinerComponent'
>;

const ImperialCarabinerComponent = ({ route }: Props) => {
  const { id } = route.params;
  const { data: carabiner } = useGetCarabiner(id);
  return (
    <BackgroundComponent>
      <BubbleComponent>
        <View>
          <Text>{carabiner?.brand}</Text>
          <Text>{carabiner?.id}</Text>
          <Text>{carabiner?.dateOfPurchase}</Text>
          <Text>{carabiner?.inspectedBy}</Text>
          <Text>{carabiner?.lastInspection}</Text>
          <Text>{carabiner?.lentBy}</Text>
          <Text>{carabiner?.lentTo}</Text>
          <Text>{carabiner?.manufacturerExpiry}</Text>
          <Text>{carabiner?.model}</Text>
          <Text>{carabiner?.nextInspection}</Text>
          <Text>{carabiner?.returnedDate}</Text>
          <Text>{carabiner?.storageLocation}</Text>
          <Text>{carabiner?.toughTag}</Text>
        </View>
      </BubbleComponent>
    </BackgroundComponent>
  );
};

export default ImperialCarabinerComponent;
