import { searchUsers } from '@api/users/usersService';
import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import { borderRadius, spacing } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { Button } from '@ui/Button';
import { Card } from '@ui/Card';
import { Body, Heading } from '@ui/Typography';
import { User } from 'lucide-react-native';
import { useState } from 'react';
import { ActivityIndicator, StyleSheet, TextInput, View } from 'react-native';
import { useUserContext } from '../contexts/UserContext';

const Login = () => {
  const [cid, setCid] = useState<string>('');
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const { setUser } = useUserContext();
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();

  const handleOnPress = async () => {
    if (!cid.trim()) {
      setError('Please enter your CID');
      return;
    }

    setIsLoading(true);
    setError(null);

    try {
      const users = await searchUsers({ cid });
      if (users && users.length > 0) {
        const user = users[0];
        console.log(user);
        setUser(user);
        navigation.navigate('Home');
      } else {
        setError('Invalid CID or user not found');
      }
    } catch (err) {
      setError('An error occurred during login');
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <BackgroundComponent>
      <View style={styles.container}>
        <View style={styles.header}>
          <Heading style={styles.title}>ICMC Inventory</Heading>
          <Body style={styles.subtitle}>Enter CID to continue</Body>
        </View>

        <Card style={styles.loginCard}>
          <View style={styles.inputContainer}>
            <User
              size={20}
              color="rgba(255, 255, 255, 0.5)"
              style={styles.inputIcon}
            />
            <TextInput
              style={styles.input}
              placeholder="College ID (CID)"
              placeholderTextColor="rgba(255, 255, 255, 0.4)"
              onChangeText={setCid}
              value={cid}
              autoFocus
              autoCapitalize="none"
            />
          </View>

          {error && <Body style={styles.errorText}>{error}</Body>}

          <Button
            title={isLoading ? '' : 'Login'}
            onPress={handleOnPress}
            variant="primary"
            style={styles.button}
            disabled={isLoading}
          >
            {isLoading && <ActivityIndicator color="#fff" />}
          </Button>
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
    justifyContent: 'center',
  },
  errorText: {
    color: '#ff6b6b',
    marginBottom: spacing.medium,
    textAlign: 'center',
  },
});

export default Login;
