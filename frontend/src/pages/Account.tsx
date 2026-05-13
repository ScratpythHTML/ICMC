import { useUserContext } from '@contexts/UserContext';
import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import { colours, spacing, borderRadius } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { Card } from '@ui/Card';
import { Body, Heading, Subheading, Label } from '@ui/Typography';
import { LogOut, Settings, User, Shield, Mail, Hash } from 'lucide-react-native';
import { StyleSheet, TouchableOpacity, View, ScrollView } from 'react-native';

const Account = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const { user, setUser } = useUserContext();

  const handleLogout = () => {
    setUser(null);
    navigation.reset({
      index: 0,
      routes: [{ name: 'Login' }],
    });
  };

  return (
    <BackgroundComponent>
      <ScrollView contentContainerStyle={styles.container}>
        <View style={styles.profileHeader}>
          <View style={styles.avatarContainer}>
            <User size={48} color={colours.blue} />
          </View>
          <View style={styles.profileInfo}>
            <Heading style={styles.userName}>{user?.fullName || 'Guest'}</Heading>
            <View style={styles.roleBadge}>
              <Shield size={12} color={user?.isAdmin ? colours.purple : colours.blue} />
              <Label style={styles.roleText}>{user?.isAdmin ? 'ADMINISTRATOR' : 'MEMBER'}</Label>
            </View>
          </View>
        </View>

        <Subheading style={styles.sectionTitle}>Details</Subheading>
        <Card style={styles.detailsCard}>
          <View style={styles.detailRow}>
            <Mail size={18} color={colours.textMuted} />
            <View>
              <Label>Email</Label>
              <Body>{user?.email || 'N/A'}</Body>
            </View>
          </View>
          <View style={styles.divider} />
          <View style={styles.detailRow}>
            <Hash size={18} color={colours.textMuted} />
            <View>
              <Label>CID</Label>
              <Body>{user?.cid || 'N/A'}</Body>
            </View>
          </View>
        </Card>

        <Subheading style={styles.sectionTitle}>Settings</Subheading>
        <Card style={styles.menuSection}>
          <TouchableOpacity style={styles.menuItem}>
            <Settings size={20} color={colours.textPrimary} style={styles.menuIcon} />
            <Body style={styles.menuText}>App Preferences</Body>
          </TouchableOpacity>
          <View style={styles.divider} />
          <TouchableOpacity style={styles.menuItem} onPress={handleLogout}>
            <LogOut
              size={20}
              color={colours.pink}
              style={styles.menuIcon}
            />
            <Body style={[styles.menuText, { color: colours.pink }]}>
              Sign Out
            </Body>
          </TouchableOpacity>
        </Card>

        <View style={styles.footer}>
          <Label style={styles.version}>VERSION 2.0.0 (MUTED REDESIGN)</Label>
        </View>
      </ScrollView>
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  container: {
    padding: spacing.medium,
  },
  profileHeader: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing.medium,
    marginVertical: spacing.large,
  },
  avatarContainer: {
    width: 80,
    height: 80,
    borderRadius: 40,
    backgroundColor: colours.surface,
    alignItems: 'center',
    justifyContent: 'center',
    borderWidth: 1,
    borderColor: colours.whiteOpacity,
  },
  profileInfo: {
    flex: 1,
  },
  userName: {
    marginBottom: spacing.xxSmall,
  },
  roleBadge: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing.xSmall,
    backgroundColor: colours.whiteOpacity,
    paddingHorizontal: spacing.small,
    paddingVertical: spacing.xxSmall,
    borderRadius: 4,
    alignSelf: 'flex-start',
  },
  roleText: {
    fontSize: 10,
    fontWeight: '700',
  },
  sectionTitle: {
    marginTop: spacing.large,
    marginBottom: spacing.small,
    fontSize: 14,
    color: colours.textMuted,
    textTransform: 'uppercase',
    letterSpacing: 1,
  },
  detailsCard: {
    gap: spacing.medium,
  },
  detailRow: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing.medium,
  },
  menuSection: {
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
    fontSize: 16,
    fontWeight: '600',
  },
  divider: {
    height: 1,
    backgroundColor: colours.whiteOpacity,
    marginHorizontal: spacing.medium,
  },
  footer: {
    marginTop: spacing.xxxLarge,
    alignItems: 'center',
    paddingBottom: spacing.large,
  },
  version: {
    fontSize: 10,
    letterSpacing: 1,
  },
});

export default Account;