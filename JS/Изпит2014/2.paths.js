function solve(args) {
  var key,
      matrix = args.slice(1).map(function(line) {
            return line.split(' ');
      }),
    directions = {
      d: +1,
      u: -1,
      l: -1,
      r: +1
    },
    visited = {},
    row, col, sum;

  function getValueAt(row, col) {
    return (1 << row) + col;
  }

  row = 0;
  col = 0;
  sum = 0;

  while (true) {
    if (!matrix[row] || !matrix[row][col]) {
      return 'successed with ' + sum;
    }
    key = row + ';' + col;
    if (visited[key]) {
      return 'failed at (' + row + ', ' + col + ')';
    }

    visited[key] = true;
    sum += getValueAt(row, col);
    var dir = matrix[row][col];
    row += directions[dir[0]];
    col += directions[dir[1]];
  }
}
solve([ '3 5',
        'dr dl dr ur ul',
        'dr dr ul ur ur',
        'dl dr ur dl ur' 
]);