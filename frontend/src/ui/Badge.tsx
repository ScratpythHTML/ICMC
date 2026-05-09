import { borderRadius, colours, spacing } from '@styles/variables';
import { StyleSheet, View } from 'react-native';
import { Label } from './Typography';

interface BadgeProps {
  label: string;
  color?: string;
  backgroundColor?: string;
}

export const Badge = ({
  label,
  color = colours.black,
  backgroundColor = colours.whiteOpacity,
}: BadgeProps) => (
  <View style={[styles.badge, { backgroundColor }]}>
    <Label style={[styles.label, { color }]}>{label}</Label>
  </View>
);

const styles = StyleSheet.create({
  badge: {
    paddingHorizontal: spacing.small,
    paddingVertical: spacing.xSmall,
    borderRadius: borderRadius.medium,
    alignSelf: 'flex-start',
  },
  label: {
    fontSize: 10,
    marginBottom: 0,
  },
});
