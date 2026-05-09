import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import HeaderComponent from '@ui/HeaderComponent';
import { StyleSheet, Text, TouchableOpacity, View } from 'react-native';

const Imperial = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const handleOnPress = () => {
    navigation.navigate('ImperialBelayDevicesComponent');
  };
  return (
    <BackgroundComponent>
      <HeaderComponent />
      <View style={styles.container}>
        <TouchableOpacity onPress={handleOnPress}>
          <BubbleComponent>
            <Text>Belay Devices</Text>
          </BubbleComponent>
        </TouchableOpacity>
      </View>
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
});
export default Imperial;
