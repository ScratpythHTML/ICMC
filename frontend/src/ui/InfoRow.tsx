import { spacing } from '@styles/variables';
import { StyleSheet, View } from 'react-native';
import { Body, Label } from './Typography';

interface InfoRowProps {
  label: string;
  value?: string | number;
  last?: boolean;
}

export const InfoRow = ({ label, value, last }: InfoRowProps) => (
  <View style={[styles.container, last ? { borderBottomWidth: 0 } : {}]}>
    <Label style={styles.label}>{label}</Label>
    <Body style={styles.value}>{value || '—'}</Body>
  </View>
);

const styles = StyleSheet.create({
  container: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    paddingVertical: spacing.small,
    borderBottomWidth: 1,
    borderBottomColor: 'rgba(255, 255, 255, 0.1)',
  },
  label: {
    marginBottom: 0,
    flex: 1,
  },
  value: {
    flex: 2,
    textAlign: 'right',
  },
});
