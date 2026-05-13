import { borderRadius, colours, spacing } from '@styles/variables';
import { type StyleProp, StyleSheet, View, type ViewStyle } from 'react-native';

interface CardProps {
  children: React.ReactNode;
  style?: StyleProp<ViewStyle>;
}

export const Card = ({ children, style }: CardProps) => {
  return (
    <View style={[styles.container, style]}>
      <View style={styles.content}>{children}</View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    borderRadius: borderRadius.large,
    backgroundColor: colours.surface,
    borderWidth: 1,
    borderColor: colours.whiteOpacity,
    overflow: 'hidden',
  },
  content: {
    padding: spacing.medium,
  },
});
