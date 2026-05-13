import { useUserContext } from '@contexts/UserContext';
import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import { colours, spacing, borderRadius } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { Card } from '@ui/Card';
import { Body, Heading } from '@ui/Typography';
import { User, LogIn } from 'lucide-react-native';
import { useState } from 'react';
import { ActivityIndicator, StyleSheet, TextInput, View, TouchableOpacity } from 'react-native';
import { searchUsers } from '@api/users/usersService';

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
        setUser(user);
        navigation.reset({
          index: 0,
          routes: [{ name: 'Main' }],
        });
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
          <Heading style={styles.title}>ICMC</Heading>
          <Body style={styles.subtitle}>Inventory Management</Body>
        </View>

        <Card style={styles.loginCard}>
          <View style={styles.inputContainer}>
            <User
              size={20}
              color={colours.textMuted}
              style={styles.inputIcon}
            />
            <TextInput
              style={styles.input}
              placeholder="College ID (CID)"
              placeholderTextColor={colours.textMuted}
              onChangeText={setCid}
              value={cid}
              autoFocus
              autoCapitalize="none"
              keyboardAppearance="dark"
            />
          </View>

          {error && <Body style={styles.errorText}>{error}</Body>}

          <TouchableOpacity 
            style={[styles.button, isLoading && styles.buttonDisabled]} 
            onPress={handleOnPress}
            disabled={isLoading}
          >
            {isLoading ? (
              <ActivityIndicator color="#fff" />
            ) : (
              <>
                <LogIn size={20} color="#fff" />
                <Body style={styles.buttonText}>Sign In</Body>
              </>
            )}
          </TouchableOpacity>
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
    marginBottom: spacing.xxxLarge,
    alignItems: 'center',
  },
  title: {
    fontSize: 48,
    marginBottom: 0,
    color: colours.blue,
    fontWeight: '800',
  },
  subtitle: {
    letterSpacing: 4,
    textTransform: 'uppercase',
    fontSize: 10,
    color: colours.textMuted,
    marginTop: spacing.xxSmall,
  },
  loginCard: {
    width: '100%',
    padding: spacing.large,
  },
  inputContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    backgroundColor: colours.surfaceLight,
    borderRadius: borderRadius.medium,
    paddingHorizontal: spacing.medium,
    marginBottom: spacing.large,
    borderWidth: 1,
    borderColor: colours.whiteOpacity,
  },
  inputIcon: {
    marginRight: spacing.small,
  },
  input: {
    flex: 1,
    height: 50,
    color: colours.textPrimary,
    fontSize: 16,
  },
  button: {
    width: '100%',
    height: 50,
    backgroundColor: colours.purple,
    borderRadius: borderRadius.medium,
    flexDirection: 'row',
    justifyContent: 'center',
    alignItems: 'center',
    gap: spacing.small,
  },
  buttonDisabled: {
    opacity: 0.6,
  },
  buttonText: {
    color: '#fff',
    fontWeight: '700',
  },
  errorText: {
    color: colours.error,
    marginBottom: spacing.medium,
    textAlign: 'center',
    fontSize: 14,
  },
});

export default Login;
