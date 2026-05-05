import type { RootStackParamList } from '@navigation/BootRouter';
import type { NativeStackScreenProps } from '@react-navigation/native-stack';
import { Button, View } from 'react-native';

type HomeProps = NativeStackScreenProps<RootStackParamList, 'Home'>;

const Home = ({ navigation }: HomeProps) => {
  return (
    <View style={{ paddingTop: 100 }}>
      <Button title="ICMC" />
    </View>
  );
};

export default Home;
