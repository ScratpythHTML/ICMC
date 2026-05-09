import { StorageLocation } from '@api/common/enums';
import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import { colours, spacing } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { Card } from '@ui/Card';
import HeaderComponent from '@ui/HeaderComponent';
import { Body, Heading, Subheading } from '@ui/Typography';
import { MapPin } from 'lucide-react-native';
import { StyleSheet, TouchableOpacity, View } from 'react-native';

const Home = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();

  const handleOnWestwayPress = () => {
    navigation.navigate('Storage', {
      storageLocation: StorageLocation.Westway,
    });
  };

  const handleOnImperialPress = () => {
    navigation.navigate('Storage', {
      storageLocation: StorageLocation.Imperial,
    });
  };

  return (
    <BackgroundComponent>
      <HeaderComponent />
      <View style={styles.content}>
        <View style={styles.welcomeSection}>
          <Heading style={styles.welcomeText}>ICMC Gear</Heading>
          <Body style={styles.subtitle}>
            Select a storage location to browse inventory
          </Body>
        </View>

        <TouchableOpacity
          style={styles.cardWrapper}
          onPress={handleOnWestwayPress}
          activeOpacity={0.8}
        >
          <Card
            style={styles.card}
            gradientColors={[colours.purpleLight, 'transparent']}
          >
            <View style={styles.cardContent}>
              <MapPin size={32} color="#fff" />
              <Subheading style={styles.cardTitle}>Westway</Subheading>
              <Body style={styles.cardDescription}>
                Main climbing wall storage
              </Body>
            </View>
          </Card>
        </TouchableOpacity>

        <TouchableOpacity
          style={styles.cardWrapper}
          onPress={handleOnImperialPress}
          activeOpacity={0.8}
        >
          <Card
            style={styles.card}
            gradientColors={[colours.blue, 'transparent']}
          >
            <View style={styles.cardContent}>
              <MapPin size={32} color="#fff" />
              <Subheading style={styles.cardTitle}>Imperial</Subheading>
              <Body style={styles.cardDescription}>
                On-campus storage locker
              </Body>
            </View>
          </Card>
        </TouchableOpacity>
      </View>
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  content: {
    flex: 1,
    padding: spacing.medium,
    justifyContent: 'center',
  },
  welcomeSection: {
    marginBottom: spacing.xxLarge,
    alignItems: 'center',
  },
  welcomeText: {
    color: '#fff',
    fontSize: 32,
    marginBottom: spacing.xSmall,
  },
  subtitle: {
    color: '#fff',
    opacity: 0.8,
    textAlign: 'center',
  },
  cardWrapper: {
    marginBottom: spacing.large,
    width: '100%',
  },
  card: {
    height: 150,
    justifyContent: 'center',
  },
  cardContent: {
    alignItems: 'center',
    justifyContent: 'center',
  },
  cardTitle: {
    color: '#fff',
    fontSize: 24,
    marginTop: spacing.small,
    marginBottom: 0,
  },
  cardDescription: {
    color: '#fff',
    opacity: 0.7,
  },
});

export default Home;
