import type { RootStackParamList } from '@navigation/BootRouter';
import type { NativeStackScreenProps } from '@react-navigation/native-stack';
import { View } from 'react-native';

type WestwayProps = NativeStackScreenProps<RootStackParamList, 'Westway'>;

const Westway = ({ navigation }: WestwayProps) => {
  return <View></View>;
};

export default Westway;
