import ImperialPreview from '@components/account/ImperialPreview';
import WestwayPreview from '@components/account/WestwayPreview';
import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import { spacing } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import HeaderComponent from '@ui/HeaderComponent';
import { StyleSheet, TouchableOpacity, View } from 'react-native';

const Home = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const handleOnWestwayPress = () => {
    navigation.navigate('Westway');
  };
  const handleOnImperialPress = () => {
    navigation.navigate('Imperial');
  };
  return (
    <View style={styles.container}>
      <BackgroundComponent>
        <HeaderComponent />
        <View style={styles.content}>
          <TouchableOpacity style={styles.card} onPress={handleOnWestwayPress}>
            <BubbleComponent style={styles.bubble}>
              <WestwayPreview />
            </BubbleComponent>
          </TouchableOpacity>
          <TouchableOpacity style={styles.card} onPress={handleOnImperialPress}>
            <BubbleComponent style={styles.bubble}>
              <ImperialPreview />
            </BubbleComponent>
          </TouchableOpacity>
        </View>
      </BackgroundComponent>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: 'column',
  },
  content: {
    flex: 1,
    alignItems: 'center',
  },
  card: {
    flex: 1,
    width: '90%',
    padding: spacing.large,
  },
  bubble: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
});

export default Home;
