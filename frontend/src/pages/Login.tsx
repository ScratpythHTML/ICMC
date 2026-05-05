import type { RootStackParamList } from '@navigation/BootRouter';
import type { NativeStackScreenProps } from '@react-navigation/native-stack';
import { View } from 'react-native';

type LoginProps = NativeStackScreenProps<RootStackParamList, 'Login'>;

const Login = ({ navigation }: LoginProps) => {
  return <View></View>;
};

export default Login;
