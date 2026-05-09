import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import { borderRadius, spacing } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { Button } from '@ui/Button';
import { Card } from '@ui/Card';
import { Body, Heading } from '@ui/Typography';
import { Lock } from 'lucide-react-native';
import { useRef } from 'react';
import { StyleSheet, TextInput, View } from 'react-native';

const Login = () => {
  const passwordRef = useRef<string>('');
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();

  const handleChangeText = (value: string) => {
    passwordRef.current = value;
  };

  const handleOnPress = () => {
    if (passwordRef.current === 'ICMC') {
      navigation.navigate('Home');
    }
  };

  return (
    <BackgroundComponent>
      <View style={styles.container}>
        <View style={styles.header}>
          <Heading style={styles.title}>ICMC Inventory</Heading>
          <Body style={styles.subtitle}>Enter password to continue</Body>
        </View>

        <Card style={styles.loginCard}>
          <View style={styles.inputContainer}>
            <Lock
              size={20}
              color="rgba(255, 255, 255, 0.5)"
              style={styles.inputIcon}
            />
            <TextInput
              style={styles.input}
              placeholder="Password"
              placeholderTextColor="rgba(255, 255, 255, 0.4)"
              onChangeText={handleChangeText}
              secureTextEntry
              autoFocus
            />
          </View>
          <Button
            title="Access System"
            onPress={handleOnPress}
            variant="primary"
            style={styles.button}
          />
        </Card>
      </View>
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: spacing.medium,
    justifyContent: 'center',
    alignItems: 'center',
  },
  header: {
    marginBottom: spacing.xxLarge,
    alignItems: 'center',
  },
  title: {
    color: '#fff',
    fontSize: 36,
    marginBottom: spacing.xSmall,
  },
  subtitle: {
    color: '#fff',
    opacity: 0.7,
  },
  loginCard: {
    width: '100%',
    padding: spacing.large,
  },
  inputContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    backgroundColor: 'rgba(255, 255, 255, 0.1)',
    borderRadius: borderRadius.medium,
    paddingHorizontal: spacing.medium,
    marginBottom: spacing.large,
    borderWidth: 1,
    borderColor: 'rgba(255, 255, 255, 0.1)',
  },
  inputIcon: {
    marginRight: spacing.small,
  },
  input: {
    flex: 1,
    height: 50,
    color: '#fff',
    fontSize: 16,
  },
  button: {
    width: '100%',
    height: 50,
  },
});

export default Login;
