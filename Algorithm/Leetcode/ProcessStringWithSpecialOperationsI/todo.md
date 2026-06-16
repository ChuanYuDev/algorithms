//  * remove the last character
//      endIdx -= 1
//  # duplicate
//  % reverse
//      (startIdx, endIdx) = (endIdx, startIdx)
//      0123
//      abcd
//      
//      s   e   s       op
//              0123
//      0   3   abcd
//      0   2   abcd    *
//      0   2   cbad    %
//      0   5   cbacba  #
//
//  list<char> list
//  startIdx, endIdx = -1
//  for i from 0 to length -1
//      if (s[i] == '*')
//          if (endIdx == -1) continue
//          endIdx -= 1
//          continue
//      if (s[i] == '#')
//          list.Count
//          continue
//      if (s[i] == '%')
//          continue
//
//      list.Add(s[i])
