import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import { colours, fonts, spacing } from '@styles/variables';
import { StyleSheet, Text, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';

const Account = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();
  const insets = useSafeAreaInsets();

  return (
    <View style={[styles.component, { paddingTop: insets.top }]}>
      <Text style={styles.title}>Account</Text>
    </View>
  );
};
const styles = StyleSheet.create({
  component: {
    flex: 1,
    display: 'flex',
    flexDirection: 'column',
    paddingHorizontal: spacing.medium,
    gap: spacing.medium,
    width: '100%',
    backgroundColor: colours.purpleLight,
  },
  title: {
    fontFamily: fonts.regular,
    fontSize: fonts.sizeExtraLarge,
    textAlign: 'center',
  },
});

export default Account;
