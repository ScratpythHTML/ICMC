import { useUserContext } from '@contexts/UserContext';
import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import { colours, spacing } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { Card } from '@ui/Card';
import HeaderComponent from '@ui/HeaderComponent';
import { Body, Heading } from '@ui/Typography';
import { LogOut, Settings, User } from 'lucide-react-native';
import { StyleSheet, TouchableOpacity, View } from 'react-native';

const Account = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const { user, setUser } = useUserContext();

  const handleLogout = () => {
    setUser(null);
    navigation.navigate('Login');
  };

  return (
    <BackgroundComponent>
      <HeaderComponent />
      <View style={styles.container}>
        <View style={styles.profileSection}>
          <View style={styles.avatarContainer}>
            <User size={64} color="#fff" />
          </View>
          <Heading style={styles.userName}>
            {user ? `${user.firstName} ${user.surname}` : 'Guest'}
          </Heading>
          <Body style={styles.userRole}>
            {user?.isAdmin ? 'Administrator' : 'ICMC Member'}
          </Body>
        </View>

        <Card style={styles.menuSection}>
          <TouchableOpacity style={styles.menuItem}>
            <Settings size={20} color="#fff" style={styles.menuIcon} />
            <Body style={styles.menuText}>Preferences</Body>
          </TouchableOpacity>
          <View style={styles.divider} />
          <TouchableOpacity style={styles.menuItem} onPress={handleLogout}>
            <LogOut
              size={20}
              color={colours.purpleLight}
              style={styles.menuIcon}
            />
            <Body style={[styles.menuText, { color: colours.purpleLight }]}>
              Logout
            </Body>
          </TouchableOpacity>
        </Card>

        <View style={styles.footer}>
          <Body style={styles.version}>v1.0.0</Body>
        </View>
      </View>
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: spacing.medium,
  },
  profileSection: {
    alignItems: 'center',
    marginVertical: spacing.xxLarge,
  },
  avatarContainer: {
    width: 100,
    height: 100,
    borderRadius: 50,
    backgroundColor: 'rgba(255, 255, 255, 0.2)',
    alignItems: 'center',
    justifyContent: 'center',
    marginBottom: spacing.medium,
  },
  userName: {
    color: '#fff',
    marginBottom: 0,
  },
  userRole: {
    color: '#fff',
    opacity: 0.7,
  },
  menuSection: {
    marginTop: spacing.large,
    padding: 0,
  },
  menuItem: {
    flexDirection: 'row',
    alignItems: 'center',
    padding: spacing.medium,
  },
  menuIcon: {
    marginRight: spacing.medium,
  },
  menuText: {
    color: '#fff',
    fontSize: 16,
  },
  divider: {
    height: 1,
    backgroundColor: 'rgba(255, 255, 255, 0.1)',
    marginHorizontal: spacing.medium,
  },
  footer: {
    marginTop: 'auto',
    alignItems: 'center',
    paddingBottom: spacing.large,
  },
  version: {
    color: '#fff',
    opacity: 0.5,
    fontSize: 12,
  },
});

export default Account;
