import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import { borderRadius, spacing } from '@styles/variables';
import { ChevronLeft, User } from 'lucide-react-native';
import { Pressable, StyleSheet, View } from 'react-native';
import { Label } from './Typography';

const HeaderComponent = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const onLeftPress = () => navigation.goBack();
  const onRightPress = () => navigation.navigate('Account');
  return (
    <View style={styles.container}>
      <View style={styles.leftSection}>
        <Pressable style={styles.button} onPress={onLeftPress}>
          <ChevronLeft size={20} color="#fff" />
          <Label style={styles.label}>Back</Label>
        </Pressable>
      </View>
      <View style={styles.rightSection}>
        <Pressable style={styles.button} onPress={onRightPress}>
          <User size={20} color="#fff" />
          <Label style={styles.label}>Account</Label>
        </Pressable>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flexDirection: 'row',
    paddingHorizontal: spacing.medium,
    paddingVertical: spacing.small,
    alignItems: 'center',
    justifyContent: 'space-between',
  },
  leftSection: {
    flex: 1,
    alignItems: 'flex-start',
  },
  rightSection: {
    flex: 1,
    alignItems: 'flex-end',
  },
  button: {
    gap: spacing.xSmall,
    flexDirection: 'row',
    alignItems: 'center',
    backgroundColor: 'rgba(255, 255, 255, 0.1)',
    borderRadius: borderRadius.xxLarge,
    paddingVertical: spacing.small,
    paddingHorizontal: spacing.medium,
  },
  label: {
    color: '#fff',
    marginBottom: 0,
  },
});

export default HeaderComponent;
