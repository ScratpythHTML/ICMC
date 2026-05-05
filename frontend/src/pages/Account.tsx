import type { RootStackParamList } from '@navigation/BootRouter';
import type { NativeStackScreenProps } from '@react-navigation/native-stack';
import { View } from 'react-native';

type AccountProps = NativeStackScreenProps<RootStackParamList, 'Account'>;

const Account = ({ navigation }: AccountProps) => {
  return <View></View>;
};

export default Account;
