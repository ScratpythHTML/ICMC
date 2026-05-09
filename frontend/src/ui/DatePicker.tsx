import DateTimePicker, {
  type DateTimePickerEvent,
} from '@react-native-community/datetimepicker';
import { borderRadius, colours, spacing } from '@styles/variables';
import { useState } from 'react';
import { Platform, StyleSheet, TouchableOpacity, View } from 'react-native';
import { Body, Label } from './Typography';

interface DatePickerProps {
  label: string;
  value?: string; // YYYY-MM-DD
  onChange: (date: string) => void;
}

export const DatePicker = ({ label, value, onChange }: DatePickerProps) => {
  const [show, setShow] = useState(false);

  const currentDate = value ? new Date(value) : new Date();
  // Ensure we have a valid date
  const validDate = isNaN(currentDate.getTime()) ? new Date() : currentDate;

  const handleOnChange = (event: DateTimePickerEvent, selectedDate?: Date) => {
    if (Platform.OS === 'android') {
      setShow(false);
    }

    if (selectedDate) {
      const year = selectedDate.getFullYear();
      const month = String(selectedDate.getMonth() + 1).padStart(2, '0');
      const day = String(selectedDate.getDate()).padStart(2, '0');
      // Append T00:00:00Z to ensure the backend treats this as UTC
      onChange(`${year}-${month}-${day}T00:00:00Z`);
    }
  };

  const togglePicker = () => {
    setShow(!show);
  };

  return (
    <View style={styles.container}>
      <Label style={styles.label}>{label}</Label>
      <TouchableOpacity
        style={styles.dateBox}
        onPress={togglePicker}
        activeOpacity={0.7}
      >
        <Body style={styles.dateText}>
          {value ? new Date(value).toLocaleDateString() : 'Select Date'}
        </Body>
      </TouchableOpacity>

      {show && (
        <View style={Platform.OS === 'ios' ? styles.iosPickerContainer : {}}>
          <DateTimePicker
            value={validDate}
            mode="date"
            display={Platform.OS === 'ios' ? 'spinner' : 'default'}
            onChange={handleOnChange}
            textColor="#fff" // For iOS spinner
          />
          {Platform.OS === 'ios' && (
            <TouchableOpacity
              style={styles.doneButton}
              onPress={() => setShow(false)}
            >
              <Body style={styles.doneText}>Done</Body>
            </TouchableOpacity>
          )}
        </View>
      )}
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
  dateBox: {
    backgroundColor: 'rgba(255, 255, 255, 0.1)',
    borderRadius: borderRadius.medium,
    paddingHorizontal: spacing.medium,
    paddingVertical: spacing.small,
    borderWidth: 1,
    borderColor: 'rgba(255, 255, 255, 0.1)',
    height: 50,
    justifyContent: 'center',
  },
  dateText: {
    color: '#fff',
    fontSize: 16,
  },
  iosPickerContainer: {
    backgroundColor: 'rgba(0,0,0,0.8)',
    borderRadius: borderRadius.medium,
    marginTop: spacing.small,
    padding: spacing.small,
  },
  doneButton: {
    alignItems: 'center',
    paddingVertical: spacing.small,
    borderTopWidth: 1,
    borderTopColor: 'rgba(255,255,255,0.1)',
  },
  doneText: {
    color: colours.blue,
    fontWeight: '700',
  },
});
