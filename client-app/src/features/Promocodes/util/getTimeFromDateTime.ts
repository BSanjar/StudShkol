export const TimeFromDate = (date: Date) => {
    const timeString = date.toISOString().split('T')[1];
    return new Date(timeString);
  };
  