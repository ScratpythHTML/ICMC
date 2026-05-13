import { fonts, spacing, colours } from '@styles/variables';
import type React from 'react';
import { StyleSheet, Text, type TextProps } from 'react-native';

interface TypographyProps extends TextProps {
  children: React.ReactNode;
  color?: string;
}

export const Heading = ({
  children,
  style,
  color = colours.textPrimary,
  ...props
}: TypographyProps) => (
  <Text style={[styles.heading, { color }, style]} {...props}>
    {children}
  </Text>
);

export const Subheading = ({
  children,
  style,
  color = colours.textPrimary,
  ...props
}: TypographyProps) => (
  <Text style={[styles.subheading, { color }, style]} {...props}>
    {children}
  </Text>
);

export const Body = ({ 
  children, 
  style, 
  color = colours.textSecondary, 
  ...props 
}: TypographyProps) => (
  <Text style={[styles.body, { color }, style]} {...props}>
    {children}
  </Text>
);

export const Label = ({
  children,
  style,
  color = colours.textMuted,
  ...props
}: TypographyProps) => (
  <Text style={[styles.label, { color }, style]} {...props}>
    {children}
  </Text>
);

export const Caption = ({
  children,
  style,
  color = colours.textMuted,
  ...props
}: TypographyProps) => (
  <Text style={[styles.caption, { color }, style]} {...props}>
    {children}
  </Text>
);

const styles = StyleSheet.create({
  heading: {
    fontFamily: fonts.bold,
    fontSize: fonts.sizeExtraLarge,
    marginBottom: spacing.small,
  },
  subheading: {
    fontFamily: fonts.bold,
    fontSize: fonts.sizeLarge,
    marginBottom: spacing.xSmall,
  },
  body: {
    fontFamily: fonts.regular,
    fontSize: fonts.sizeMedium,
  },
  label: {
    fontFamily: fonts.regular,
    fontSize: fonts.sizeSmall,
    textTransform: 'uppercase',
    letterSpacing: 1,
  },
  caption: {
    fontFamily: fonts.light,
    fontSize: fonts.sizeExtraSmall,
  },
});
