import { borderRadius, spacing } from '@styles/variables';
import { StyleSheet, TextInput, type TextInputProps, View } from 'react-native';
import { Label } from './Typography';

interface InputProps extends TextInputProps {
  label?: string;
}

export const Input = ({ label, style, ...props }: InputProps) => {
  return (
    <View style={styles.container}>
      {label && <Label style={styles.label}>{label}</Label>}
      <TextInput
        style={[styles.input, style]}
        placeholderTextColor="rgba(255, 255, 255, 0.4)"
        {...props}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    marginBottom: spacing.medium,
    width: '100%',
  },
  label: {
    color: '#fff',
    marginBottom: spacing.xSmall,
    opacity: 0.8,
  },
  input: {
    backgroundColor: 'rgba(255, 255, 255, 0.1)',
    borderRadius: borderRadius.medium,
    paddingHorizontal: spacing.medium,
    paddingVertical: spacing.small,
    color: '#fff',
    fontSize: 16,
    borderWidth: 1,
    borderColor: 'rgba(255, 255, 255, 0.1)',
  },
});
