import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import { borderRadius, spacing } from '@styles/variables';
import { ChevronLeft, HomeIcon } from 'lucide-react-native';
import { Pressable, StyleSheet, Text, View } from 'react-native';

const HeaderComponent = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const onLeftPress = () => navigation.goBack();
  const onRightPress = () => navigation.navigate('Account');
  return (
    <View style={styles.container}>
      <View style={styles.leftSection}>
        <Pressable style={styles.button} onPress={onLeftPress}>
          <ChevronLeft size={16} />
          <Text>Back</Text>
        </Pressable>
      </View>
      <View style={styles.rightSection}>
        <Pressable style={styles.button} onPress={onRightPress}>
          <HomeIcon size={16} />
          <Text>Account</Text>
        </Pressable>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flexDirection: 'row',
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
    gap: spacing.small,
    borderWidth: 1,
    flexDirection: 'row',
    alignItems: 'center',
    borderRadius: borderRadius.xxLarge,
    paddingVertical: spacing.small,
    paddingHorizontal: spacing.medium,
  },
});

export default HeaderComponent;
