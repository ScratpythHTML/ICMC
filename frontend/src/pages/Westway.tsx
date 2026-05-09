import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import BackgroundComponent from '@ui/BackgroundComponent';
import { BubbleComponent } from '@ui/BubbleComponent';
import HeaderComponent from '@ui/HeaderComponent';
import { ScrollView, StyleSheet, Text, TouchableOpacity, View } from 'react-native';

const Westway = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();

  const categories = [
    { label: 'Belay Devices', route: 'WestwayBelayDevicesComponent' as keyof RootStackParamList },
    { label: 'Carabiners', route: 'WestwayCarabinersComponent' as keyof RootStackParamList },
    { label: 'Crashpads', route: 'WestwayCrashpadsComponent' as keyof RootStackParamList },
    { label: 'Harnesses', route: 'WestwayHarnessesComponent' as keyof RootStackParamList },
    { label: 'Helmets', route: 'WestwayHelmetsComponent' as keyof RootStackParamList },
    { label: 'Quickdraws', route: 'WestwayQuickdrawsComponent' as keyof RootStackParamList },
    { label: 'Ropes', route: 'WestwayRopesComponent' as keyof RootStackParamList },
  ];

  return (
    <BackgroundComponent>
      <HeaderComponent />
      <ScrollView contentContainerStyle={styles.container}>
        {categories.map((category) => (
          <TouchableOpacity 
            key={category.label} 
            onPress={() => navigation.navigate(category.route as any)}
          >
            <BubbleComponent style={styles.bubble}>
              <Text>{category.label}</Text>
            </BubbleComponent>
          </TouchableOpacity>
        ))}
      </ScrollView>
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  container: {
    padding: 20,
    gap: 20,
  },
  bubble: {
    padding: 20,
    alignItems: 'center',
  }
});
export default Westway;
