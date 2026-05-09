import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import { borderRadius, colours } from '@styles/variables';
import { useRef } from 'react';
import { Pressable, StyleSheet, Text, TextInput, View } from 'react-native';

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
    <View style={styles.container}>
      <TextInput
        style={styles.passwordInputCard}
        placeholder="Password"
        placeholderTextColor={colours.black}
        onChangeText={handleChangeText}
      />
      <Pressable style={styles.loginButton} onPress={handleOnPress}>
        <Text>Login</Text>
      </Pressable>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    gap: 20,
  },
  passwordInputCard: {
    borderRadius: borderRadius.xxLarge,
    borderWidth: 2,
    padding: 20,
    borderColor: colours.orangeDark,
  },
  loginButton: {
    borderWidth: 2,
    padding: 20,
    borderRadius: borderRadius.xxLarge,
  },
});

export default Login;
