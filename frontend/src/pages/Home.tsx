import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import { Button, View } from 'react-native';

const Home = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  return (
    <View style={{ paddingTop: 100 }}>
      <Button title="ICMC" />
    </View>
  );
};

export default Home;
