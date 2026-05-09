import { borderRadius, colours, spacing } from '@styles/variables';
import { StyleSheet, View } from 'react-native';
import { Button } from './Button';
import { Body } from './Typography';

interface ConfirmToastProps {
  visible: boolean;
  message: string;
  onConfirm: () => void;
  onCancel: () => void;
}

export const ConfirmToast = ({
  visible,
  message,
  onConfirm,
  onCancel,
}: ConfirmToastProps) => {
  if (!visible) return null;

  return (
    <View style={styles.overlay}>
      <View style={styles.container}>
        <Body style={styles.message}>{message}</Body>
        <View style={styles.actions}>
          <Button
            title="Confirm"
            onPress={onConfirm}
            variant="danger"
            size="small"
            style={styles.button}
          />
          <Button
            title="Cancel"
            onPress={onCancel}
            variant="ghost"
            size="small"
            style={styles.button}
          />
        </View>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  overlay: {
    position: 'absolute',
    bottom: spacing.xLarge,
    left: spacing.medium,
    right: spacing.medium,
    zIndex: 1000,
  },
  container: {
    backgroundColor: colours.purpleDark,
    borderRadius: borderRadius.large,
    padding: spacing.medium,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 4 },
    shadowOpacity: 0.3,
    shadowRadius: 4,
    elevation: 8,
  },
  message: {
    color: '#fff',
    flex: 1,
    marginRight: spacing.small,
  },
  actions: {
    flexDirection: 'row',
    gap: spacing.small,
  },
  button: {
    minWidth: 80,
  },
});
