import { useGetGearItem } from '@api/gear-items/gearItemsApi';
import type { RootStackParamList } from '@navigation/BootRouter';
import { type RouteProp, useRoute } from '@react-navigation/native';
import { colours, spacing } from '@styles/variables';
import BackgroundComponent from '@ui/BackgroundComponent';
import { Badge } from '@ui/Badge';
import { Card } from '@ui/Card';
import HeaderComponent from '@ui/HeaderComponent';
import { InfoRow } from '@ui/InfoRow';
import { Body, Heading, Subheading } from '@ui/Typography';
import {
  formatDate,
  getGearCategoryLabel,
  getSexLabel,
  getSizeLabel,
  getStorageLocationLabel,
} from '@utils/enumHelpers';
import { ScrollView, StyleSheet, View } from 'react-native';

const GearItem = () => {
  const route = useRoute<RouteProp<RootStackParamList, 'GearItem'>>();
  const { id } = route.params;
  const { data: gearItem, isLoading } = useGetGearItem(id);

  if (isLoading) {
    return (
      <BackgroundComponent>
        <HeaderComponent />
        <View style={styles.center}>
          <Body>Loading...</Body>
        </View>
      </BackgroundComponent>
    );
  }

  if (!gearItem) {
    return (
      <BackgroundComponent>
        <HeaderComponent />
        <View style={styles.center}>
          <Body>Gear item not found.</Body>
        </View>
      </BackgroundComponent>
    );
  }

  return (
    <BackgroundComponent>
      <HeaderComponent />
      <ScrollView contentContainerStyle={styles.container}>
        <View style={styles.header}>
          <Heading style={styles.title}>{gearItem.brand}</Heading>
          <Subheading style={styles.subtitle}>
            {gearItem.model || 'Unknown Model'}
          </Subheading>
          <View style={styles.badges}>
            <Badge
              label={getGearCategoryLabel(gearItem.gearCategory)}
              backgroundColor={colours.blue}
              color="#fff"
            />
            <Badge
              label={`Tag: #${gearItem.toughTag}`}
              backgroundColor={colours.yellow}
            />
          </View>
        </View>

        <Card style={styles.section}>
          <Subheading style={styles.sectionTitle}>General Info</Subheading>
          <InfoRow
            label="Storage Location"
            value={getStorageLocationLabel(gearItem.storageLocation)}
          />
          <InfoRow label="Size" value={getSizeLabel(gearItem.size)} />
          <InfoRow label="Sex" value={getSexLabel(gearItem.sex)} />
          {gearItem.length && (
            <InfoRow label="Length" value={`${gearItem.length}m`} />
          )}
          <InfoRow
            label="Purchase Date"
            value={formatDate(gearItem.dateOfPurchase)}
            last
          />
        </Card>

        <Card style={styles.section}>
          <Subheading style={styles.sectionTitle}>
            Inspection Details
          </Subheading>
          <InfoRow
            label="Last Inspection"
            value={formatDate(gearItem.lastInspection)}
          />
          <InfoRow
            label="Next Inspection"
            value={formatDate(gearItem.nextInspection)}
          />
          <InfoRow
            label="Manufacturer Expiry"
            value={formatDate(gearItem.manufacturerExpiry)}
          />
          <InfoRow
            label="Inspected By"
            value={gearItem.inspectedBy || 'N/A'}
            last
          />
        </Card>

        {(gearItem.lentTo || gearItem.lentBy) && (
          <Card style={styles.section}>
            <Subheading style={styles.sectionTitle}>Lending Status</Subheading>
            <InfoRow label="Lent To" value={gearItem.lentTo || 'N/A'} />
            <InfoRow label="Lent By" value={gearItem.lentBy || 'N/A'} />
            <InfoRow label="Lent Date" value={formatDate(gearItem.lentDate)} />
            <InfoRow
              label="Returned Date"
              value={formatDate(gearItem.returnedDate)}
              last
            />
          </Card>
        )}
      </ScrollView>
    </BackgroundComponent>
  );
};

const styles = StyleSheet.create({
  container: {
    padding: spacing.medium,
  },
  center: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  },
  header: {
    marginBottom: spacing.large,
    alignItems: 'center',
  },
  title: {
    color: '#fff',
    marginBottom: 0,
    textAlign: 'center',
  },
  subtitle: {
    color: '#fff',
    opacity: 0.8,
    textAlign: 'center',
    marginBottom: spacing.small,
  },
  badges: {
    flexDirection: 'row',
    gap: spacing.small,
  },
  section: {
    marginBottom: spacing.medium,
  },
  sectionTitle: {
    color: '#fff',
    fontSize: 16,
    marginBottom: spacing.medium,
    borderBottomWidth: 1,
    borderBottomColor: 'rgba(255, 255, 255, 0.2)',
    paddingBottom: spacing.xSmall,
  },
});

export default GearItem;
