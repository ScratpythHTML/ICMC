import { StorageLocation } from '@api/common/enums';
import { useSearchGearItems } from '@api/gear-items/gearItemsApi';
import type { RootStackParamList } from '@navigation/BootRouter';
import { type NavigationProp, useNavigation } from '@react-navigation/native';
import { colours, spacing } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { Card } from '@ui/Card';
import HeaderComponent from '@ui/HeaderComponent';
import { Body, Heading, Label, Subheading } from '@ui/Typography';
import { AlertCircle, CheckCircle2, MapPin } from 'lucide-react-native';
import { useMemo } from 'react';
import { StyleSheet, TouchableOpacity, View } from 'react-native';

const Home = () => {
  const navigation = useNavigation<NavigationProp<RootStackParamList>>();

  const { data: allItems } = useSearchGearItems({});

  const stats = useMemo(() => {
    const s = {
      [StorageLocation.Westway]: {
        total: 0,
        available: 0,
        needInspection: 0,
      },
      [StorageLocation.Imperial]: {
        total: 0,
        available: 0,
        needInspection: 0,
      },
    };

    if (allItems) {
      for (const item of allItems) {
        const loc = item.storageLocation;
        if (s[loc]) {
          s[loc].total++;
          if (!item.lentToUserId) s[loc].available++;
          if (item.nextInspection) {
            const today = new Date();
            const inspectionDate = new Date(item.nextInspection);
            const diffTime = inspectionDate.getTime() - today.getTime();
            const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
            if (diffDays <= 30) s[loc].needInspection++;
          }
        }
      }
    }
    return s;
  }, [allItems]);

  const handleOnWestwayPress = () => {
    navigation.navigate('Storage', {
      storageLocation: StorageLocation.Westway,
    });
  };

  const handleOnImperialPress = () => {
    navigation.navigate('Storage', {
      storageLocation: StorageLocation.Imperial,
    });
  };

  const renderStats = (loc: StorageLocation) => {
    const locStats = stats[loc];
    return (
      <View style={styles.statsRow}>
        <View style={styles.stat}>
          <CheckCircle2 size={14} color={colours.yellow} />
          <Label style={styles.statLabel}>
            {locStats.available}/{locStats.total} available
          </Label>
        </View>
        <View style={styles.stat}>
          <AlertCircle
            size={14}
            color={locStats.needInspection > 0 ? colours.orangeLight : '#fff'}
          />
          <Label
            style={[
              styles.statLabel,
              locStats.needInspection > 0 && { color: colours.orangeLight },
            ]}
          >
            {locStats.needInspection} need inspection
          </Label>
        </View>
      </View>
    );
  };

  return (
    <BackgroundComponent>
      <HeaderComponent />
      <View style={styles.content}>
        <View style={styles.welcomeSection}>
          <Heading style={styles.welcomeText}>ICMC Gear</Heading>
          <Body style={styles.subtitle}>
            Select a storage location to browse inventory
          </Body>
        </View>

        <TouchableOpacity
          style={styles.cardWrapper}
          onPress={handleOnWestwayPress}
          activeOpacity={0.8}
        >
          <Card
            style={styles.card}
            gradientColors={[colours.purpleLight, 'transparent']}
          >
            <View style={styles.cardContent}>
              <MapPin size={32} color="#fff" />
              <Subheading style={styles.cardTitle}>Westway</Subheading>
              <Body style={styles.cardDescription}>
                Main climbing wall storage
              </Body>
              {renderStats(StorageLocation.Westway)}
            </View>
          </Card>
        </TouchableOpacity>

        <TouchableOpacity
          style={styles.cardWrapper}
          onPress={handleOnImperialPress}
          activeOpacity={0.8}
        >
          <Card
            style={styles.card}
            gradientColors={[colours.blue, 'transparent']}
          >
            <View style={styles.cardContent}>
              <MapPin size={32} color="#fff" />
              <Subheading style={styles.cardTitle}>Imperial</Subheading>
              <Body style={styles.cardDescription}>
                On-campus storage locker
              </Body>
              {renderStats(StorageLocation.Imperial)}
            </View>
          </Card>
        </TouchableOpacity>
      </View>
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  content: {
    flex: 1,
    padding: spacing.medium,
    justifyContent: 'center',
  },
  welcomeSection: {
    marginBottom: spacing.xxLarge,
    alignItems: 'center',
  },
  welcomeText: {
    color: '#fff',
    fontSize: 32,
    marginBottom: spacing.xSmall,
  },
  subtitle: {
    color: '#fff',
    opacity: 0.8,
    textAlign: 'center',
  },
  cardWrapper: {
    marginBottom: spacing.large,
    width: '100%',
  },
  card: {
    height: 180,
    justifyContent: 'center',
  },
  cardContent: {
    alignItems: 'center',
    justifyContent: 'center',
  },
  cardTitle: {
    color: '#fff',
    fontSize: 24,
    marginTop: spacing.small,
    marginBottom: 0,
  },
  cardDescription: {
    color: '#fff',
    opacity: 0.7,
    marginBottom: spacing.small,
  },
  statsRow: {
    flexDirection: 'row',
    gap: spacing.medium,
    marginTop: spacing.small,
  },
  stat: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: spacing.xxSmall,
  },
  statLabel: {
    color: 'rgba(255, 255, 255, 0.8)',
    marginBottom: 0,
    fontSize: 12,
    fontWeight: '600',
  },
});

export default Home;
