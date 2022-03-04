package fontys.sem3.iTrips.service;

import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.Month;
import java.time.YearMonth;
import java.time.ZoneId;
import java.time.format.TextStyle;
import java.util.*;

import static java.time.DayOfWeek.MONDAY;
import static java.time.temporal.TemporalAdjusters.previousOrSame;

public class DatesHelper {
 public static boolean dateIsInSameWeek(long millis){
  Calendar cal1 = Calendar.getInstance();
  cal1.set(Calendar.DAY_OF_WEEK, Calendar.MONDAY);
  int year1 = cal1.get(Calendar.YEAR);
  int week1 = cal1.get(Calendar.WEEK_OF_YEAR);

  Calendar cal2 = Calendar.getInstance();
  cal2.setTimeInMillis(millis);
  cal2.set(Calendar.DAY_OF_WEEK, Calendar.MONDAY);
  int year2 = cal2.get(Calendar.YEAR);
  int week2 = cal2.get(Calendar.WEEK_OF_YEAR);

  return year1 == year2 && week1 == week2;
 }

 public static Date getFirstDayOfCurrentWeek() {
// get today and clear time of day
  Calendar cal = Calendar.getInstance( TimeZone.getTimeZone("Europe/London"));
  cal.set(Calendar.HOUR_OF_DAY, 0); // ! clear would not reset the hour of day !
  cal.clear(Calendar.MINUTE);
  cal.clear(Calendar.SECOND);
  cal.clear(Calendar.MILLISECOND);

// get start of this week in milliseconds
  cal.setFirstDayOfWeek(Calendar.MONDAY);
  cal.set(Calendar.DAY_OF_WEEK, cal.getFirstDayOfWeek());
  return cal.getTime();
  /*LocalDate today = LocalDate.now();
  LocalDate monday = today.with(previousOrSame(MONDAY));
  return java.util.Date.from(monday.atStartOfDay()
          .atZone(ZoneId.systemDefault())
          .toInstant());*/
 }

 public static Date getFirstDayOfCurrentMonth() {
  Calendar cal = Calendar.getInstance( TimeZone.getTimeZone("Europe/London"));
  cal.set(Calendar.HOUR_OF_DAY, 0); // ! clear would not reset the hour of day !
  cal.clear(Calendar.MINUTE);
  cal.clear(Calendar.SECOND);
  cal.clear(Calendar.MILLISECOND);
  cal.set(Calendar.DAY_OF_MONTH, 1);
  Date date = cal.getTime();
  return cal.getTime();
 }

 public static boolean dateIsAddable(Date date) {

  LocalDate date1 = new java.sql.Date(date.getTime()).toLocalDate();
  Date today = new Date();
   if(!date.after(today)){
    return getPrevious12Months().contains(YearMonth.from(date1));
   }
   return false;
 }

 public static boolean dateIsInRange(Date start, Date end, Date given){
  return !(given.before(start) || given.after(end));
 }

 public static int getCurrentMontIndex(){
  java.util.Date date= new Date();
  Calendar cal = Calendar.getInstance();
  cal.setTime(date);
  return cal.get(Calendar.MONTH);
 }

 public static int getMonthIndex(Date date) {
  Calendar cal = Calendar.getInstance();
  cal.setTime(date);
  return cal.get(Calendar.MONTH);
 }

 public static List<YearMonth> getPrevious12Months(){
  List<YearMonth> months = new ArrayList<>();
  YearMonth currentMonth = YearMonth.now();
  for (int i = 11;i >= 1; i--){
   months.add(currentMonth.plusMonths(-i));
  }
  months.add(currentMonth);
  return months;
 }

 public static List<String> getPrevious12MonthsStrings(){
  YearMonth currentMonth = YearMonth.now();
  List<String> monthNames = new ArrayList<>();
  for (int i = 11;i >= 1; i--){
   Month month = Month.of(currentMonth.plusMonths(-i).getMonthValue());
   String str = month.getDisplayName(TextStyle.SHORT, Locale.ENGLISH);
   monthNames.add(str);
  }
  monthNames.add(Month.of(currentMonth.getMonthValue()).getDisplayName(TextStyle.SHORT, Locale.ENGLISH));
  return monthNames;
 }


}
