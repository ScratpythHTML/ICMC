import { borderRadius, colours, spacing } from '@styles/variables';
import {
  StyleSheet,
  TouchableOpacity,
  type TouchableOpacityProps,
} from 'react-native';
import { Body } from './Typography';

interface ButtonProps extends TouchableOpacityProps {
  title: string;
  variant?: 'primary' | 'secondary' | 'danger' | 'ghost';
  size?: 'small' | 'medium' | 'large';
}

export const Button = ({
  title,
  variant = 'primary',
  size = 'medium',
  style,
  ...props
}: ButtonProps) => {
  const getVariantStyle = () => {
    switch (variant) {
      case 'primary':
        return { backgroundColor: colours.purple };
      case 'secondary':
        return { backgroundColor: colours.blue };
      case 'danger':
        return { backgroundColor: colours.purpleLight };
      case 'ghost':
        return {
          backgroundColor: 'transparent',
          borderWidth: 1,
          borderColor: colours.whiteOpacity,
        };
      default:
        return { backgroundColor: colours.purple };
    }
  };

  const getSizeStyle = () => {
    switch (size) {
      case 'small':
        return {
          paddingVertical: spacing.xSmall,
          paddingHorizontal: spacing.small,
        };
      case 'medium':
        return {
          paddingVertical: spacing.small,
          paddingHorizontal: spacing.medium,
        };
      case 'large':
        return {
          paddingVertical: spacing.medium,
          paddingHorizontal: spacing.large,
        };
      default:
        return {
          paddingVertical: spacing.small,
          paddingHorizontal: spacing.medium,
        };
    }
  };

  return (
    <TouchableOpacity
      style={[styles.button, getVariantStyle(), getSizeStyle(), style]}
      {...props}
    >
      <Body style={styles.text}>{title}</Body>
    </TouchableOpacity>
  );
};

const styles = StyleSheet.create({
  button: {
    borderRadius: borderRadius.medium,
    alignItems: 'center',
    justifyContent: 'center',
  },
  text: {
    color: '#fff',
    fontWeight: '600',
  },
});
