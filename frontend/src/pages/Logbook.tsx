import { colours, spacing } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { Body, Heading } from '@ui/Typography';
import { useState } from 'react';
import { ScrollView, StyleSheet, View, RefreshControl } from 'react-native';

const Logbook = () => {
  const [refreshing, setRefreshing] = useState(false);

  const onRefresh = () => {
    setRefreshing(true);
    // Simulate refresh for now since it's a placeholder
    setTimeout(() => setRefreshing(false), 1000);
  };

  return (
    <BackgroundComponent>
      <ScrollView 
        contentContainerStyle={styles.container}
        refreshControl={
          <RefreshControl 
            refreshing={refreshing} 
            onRefresh={onRefresh} 
            tintColor={colours.blue}
            colors={[colours.blue]}
          />
        }
      >
        <Heading>Logbook</Heading>
        <Body>View historical lending records.</Body>
      </ScrollView>
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: spacing.medium,
  },
});

export default Logbook;
